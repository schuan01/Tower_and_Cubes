using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{

    public int waveCount;
    public int startEnemies = 4;//Empieza con 4 enemigos

    public int enemiesAddedAfterWave = 2;//Enemigos que se agregan por oleada

    public float timeBeforeNextWave = 5.0f;//3 segundos

    private bool waveStart = false;


    private float timeLapsedSpawns = 0;
    private float timeLapsedWaves = 0;

    public float timeBetweenSpawns = 2.0f;

	public float spawnDecreser = 0.2f; 

    private int currentEnemiesSpawn;

	private int enemiesLeft;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeLapsedSpawns += Time.deltaTime;
        timeLapsedWaves += Time.deltaTime;


        //Chequea el tiempo entre oleadas
        if (timeLapsedWaves >= timeBeforeNextWave && !waveStart)
        {
            waveStart = true;
            Debug.Log("Empezo oleada");
        }

        //Chequea el tiempo entre aparicion de enemigos
        if (timeLapsedSpawns >= timeBetweenSpawns && waveStart)
        {

            if (currentEnemiesSpawn >= startEnemies)
            {

				ResetWave();
            }
            else
            {
                SpawnEnemy();
                timeLapsedSpawns = 0;
            }
        }


    }

    void SpawnEnemy()
    {
		GetComponent<SpawnEnemy>().SpawnRandomEnemy();
        currentEnemiesSpawn++;
    }

    void ResetWave()
    {
		waveCount++;
        waveStart = false;
        timeLapsedWaves = 0;
        Debug.Log("Termino oleada");
        currentEnemiesSpawn = 0;
        startEnemies += enemiesAddedAfterWave;
		timeBetweenSpawns -= spawnDecreser;
    }


}
