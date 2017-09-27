using System;
using System.Collections.Generic;
using UnityEngine;
//Spawn an enemy in a random Point each 2 seconds
public class SpawnEnemy : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] respawnPrefab;
    public GameObject[] respawns;

    public float timeBetweenSpawns = 2.0f;

    public float baseSpeed = 0;

    public float multiplier = 0.3f;

    public float timeBetweenSpeedChange = 4;

    public List<KeyValuePair<GameObject, float>> lstEnemies = new List<KeyValuePair<GameObject, float>>();





    void Start()
    {
        int cont = 0;
        foreach (GameObject g in respawnPrefab)
        {
            if (g.tag.Contains("enemy_normal"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, 50));
            }

            if (g.tag.Contains("enemy_explosive"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, 20));
            }

            if (g.tag.Contains("enemy_explosive_static"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, 15));

            }

            if (g.tag.Contains("enemy_giant"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, 15));
            }
            cont++;
        }

        //InvokeRepeating("SpawnRandomEnemy", 2, timeBetweenSpawns);//A partir del segundo 2, cada 2 segundos
        InvokeRepeating("ChangeSpeedMultiplier", 5, timeBetweenSpeedChange);
    }



    // Update is called once per frame
    void Update()
    {


    }

    void ChangeSpeedMultiplier()
    {
        baseSpeed = baseSpeed + multiplier;
    }

    

    GameObject ChooseRandomEnemy()
    {

        float total = 0;

        for (int i = 0; i < lstEnemies.Count; i++)
        {
            total += lstEnemies[i].Value;
            
        }

        float randomPoint = UnityEngine.Random.value * total;


        for (int i = 0; i < lstEnemies.Count; i++)
        {
            if (randomPoint < lstEnemies[i].Value)
            {
                
                return lstEnemies[i].Key;

            }
            else
            {
                randomPoint -= lstEnemies[i].Value;
            }
        }

        return lstEnemies[lstEnemies.Count - 1].Key;
    }



    public GameObject SpawnRandomEnemy()
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

            //GameObject go = Instantiate(respawnPrefab[ChooseRandomByFloat()], ground, Quaternion.identity);
            GameObject go = Instantiate(ChooseRandomEnemy(), ground, Quaternion.identity);
            
            if (piso.tag.Contains("Off"))
            {

                go.tag = go.tag + "_off";
            }

            //go.GetComponent<EnemyBase>().SetBaseVelocity(baseSpeed);

            return go;


        }

        return null;
    }
}
