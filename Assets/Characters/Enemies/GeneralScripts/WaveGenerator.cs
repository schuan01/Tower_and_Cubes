﻿
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{

    public int waveCount;
    public int startEnemies = 4;//Empieza con 4 enemigos

    public int enemiesAddedAfterWave = 3;//Enemigos que se agregan por oleada

    public float timeBeforeNextWave = 3.0f;

    public bool waveStart = false;


    public float timeLapsedSpawns = 0;
    public float timeLapsedWaves = 0;

    public float timeBetweenSpawns = 1.8f;

    public float spawnDecreser = 0.05f;

    public int currentEnemiesSpawn;

    public int enemiesLeft;

    public GameObject player;

    // Use this for initialization
    void Start()
    {
        enemiesLeft = startEnemies;
    }

    // Update is called once per frame
    void Update()
    {

        timeLapsedSpawns += Time.deltaTime;
        timeLapsedWaves += Time.deltaTime;


        //Chequea el tiempo entre oleadas
        if (timeLapsedWaves >= timeBeforeNextWave && !waveStart)
        {
            StartWave();

        }

        //Chequea el tiempo entre aparicion de enemigos
        if (timeLapsedSpawns >= timeBetweenSpawns && waveStart)
        {

            if (enemiesLeft <= 0)
            {

                ResetWave();
                timeLapsedSpawns = 0;
            }
            else if (currentEnemiesSpawn <= startEnemies)
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
        waveStart = false;
        timeLapsedWaves = 0;
        currentEnemiesSpawn = 0;
        startEnemies += enemiesAddedAfterWave;
        enemiesLeft = startEnemies;
        timeBetweenSpawns -= spawnDecreser;
        player.GetComponent<CannonScript>().ChangeShootInterval();


    }

    public void ChangeEnemiesLeft()
    {
        
        enemiesLeft--;
    }

    private void StartWave()
    {
        waveStart = true;
        enemiesLeft = startEnemies;
        waveCount++;
        GetComponent<ScoreCounter>().ChangeWave(waveCount);
    }


}
