using System;
using UnityEngine;

//Spawn an enemy in a random Point each 2 seconds
public class SpawnEnemy : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] respawnPrefab;
    public GameObject[] respawns;

    private float[] probability = new float[3];

    public float timeBetweenSpawns = 2.0f;

    void Start()
    {
        int cont = 0;
        foreach (GameObject g in respawnPrefab)
        {
            if (g.tag.Contains("enemy_normal"))
            {
                probability[cont] = 60;
            }

            if (g.tag.Contains("enemy_explosive"))
            {
                probability[cont] = 25;
            }

            if (g.tag.Contains("enemy_giant"))
            {
                probability[cont] = 15;
            }
            cont++;
        }

        InvokeRepeating("SpawnRandomEnemy", 2, timeBetweenSpawns);//A partir del segundo 2, cada 2 segundos
    }



    // Update is called once per frame
    void Update()
    {

    }

    int ChooseRandomByFloat()
    {

        float total = 0;

        foreach (float elem in probability)
        {
            total += elem;
        }

        float randomPoint = UnityEngine.Random.value * total;
        

        for (int i = 0; i < probability.Length; i++)
        {
            if (randomPoint < probability[i])
            {
                
                return i;
                
            }
            else
            {
                randomPoint -= probability[i];
            }
        }
        
        return probability.Length - 1;
    }

    void SpawnRandomEnemy()
    {
        respawns = GameObject.FindGameObjectsWithTag("terrainQuad_Border_On");//Obtiene todos los puntos,bordes;
        GameObject[] array2 = GameObject.FindGameObjectsWithTag("terrainQuad_Border_Off");//Obtiene todos los puntos,bordes;
        int array1OriginalLength = respawns.Length;
        Array.Resize<GameObject>(ref respawns, array1OriginalLength + array2.Length);
        Array.Copy(array2, 0, respawns, array1OriginalLength, array2.Length);

        //respawns = GameObject.FindGameObjectsWithTag("terrainQuad_Border_On");//Obtiene todos los puntos,bordes



        if (respawns.Length > 0)
        {
            int randomIndexLocations = UnityEngine.Random.Range(0, respawns.Length);
            //int randomIndexPrefab = UnityEngine.Random.Range(0, respawnPrefab.Length);
            GameObject piso = respawns[randomIndexLocations];


            Vector3 ground = new Vector3(respawns[randomIndexLocations].transform.position.x, 0, respawns[randomIndexLocations].transform.position.z);

            GameObject go = Instantiate(respawnPrefab[ChooseRandomByFloat()], ground, Quaternion.identity);
            if (piso.tag.Contains("Off"))
            {

                go.tag = go.tag + "_off";
            }
        }
    }
}
