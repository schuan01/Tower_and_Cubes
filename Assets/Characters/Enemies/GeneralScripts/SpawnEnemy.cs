using System;
using UnityEngine;

//Spawn an enemy in a random Point each 2 seconds
public class SpawnEnemy : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] respawnPrefab;
    public GameObject[] respawns;

    public float timeBetweenSpawns = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 2, timeBetweenSpawns);//A partir del segundo 2, cada 2 segundos
    }



    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        respawns = GameObject.FindGameObjectsWithTag("terrainQuad_Border_On");//Obtiene todos los puntos,bordes;
        GameObject[]  array2 = GameObject.FindGameObjectsWithTag("terrainQuad_Border_Off");//Obtiene todos los puntos,bordes;
        int array1OriginalLength = respawns.Length;
        Array.Resize<GameObject>(ref respawns, array1OriginalLength + array2.Length);
        Array.Copy(array2, 0, respawns, array1OriginalLength, array2.Length);

        //respawns = GameObject.FindGameObjectsWithTag("terrainQuad_Border_On");//Obtiene todos los puntos,bordes

        if (respawns.Length > 0)
        {
            int randomIndexLocations = UnityEngine.Random.Range(0, respawns.Length);
            int randomIndexPrefab = UnityEngine.Random.Range(0, respawnPrefab.Length);
            Vector3 ground = new Vector3(respawns[randomIndexLocations].transform.position.x, 0.45f, respawns[randomIndexLocations].transform.position.z);
            Instantiate(respawnPrefab[randomIndexPrefab], ground, respawns[randomIndexLocations].transform.rotation);
        }
    }
}
