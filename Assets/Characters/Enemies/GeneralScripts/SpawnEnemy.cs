using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] respawnPrefab;
    public List<GameObject> respawns;

    public float timeBetweenSpawns = 2.0f;

    public float baseSpeed = 0;

    public float multiplier = 0.3f;

    public float timeBetweenSpeedChange = 4;

    public GameObject targetGameObject;

    public int normalEnemyProbability = 40;
    public int explosiveEnemyProbability = 25;
    public int explosiveStaticEnemyProbability = 20;

    public int giantEnemyProbability = 15;

    public List<KeyValuePair<GameObject, float>> lstEnemies = new List<KeyValuePair<GameObject, float>>();

    void Start()
    {
        int cont = 0;
        foreach (GameObject g in respawnPrefab)
        {
            if (g.tag.Equals("enemy_normal"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, normalEnemyProbability));
            }

            if (g.tag.Equals("enemy_explosive"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, explosiveEnemyProbability));
            }

            if (g.tag.Equals("enemy_explosive_static"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, explosiveStaticEnemyProbability));

            }

            if (g.tag.Equals("enemy_giant"))
            {
                lstEnemies.Add(new KeyValuePair<GameObject, float>(g, giantEnemyProbability));
            }
            cont++;
        }

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
        //respawns = GameObject.FindGameObjectsWithTag("terrainQuad_Border_On");//Obtiene todos los puntos,bordes;
        //GameObject[] array2 = GameObject.FindGameObjectsWithTag("terrainQuad_Border_Off");//Obtiene todos los puntos,bordes;
        //int array1OriginalLength = respawns.Length;
        //Array.Resize<GameObject>(ref respawns, array1OriginalLength + array2.Length);
        //Array.Copy(array2, 0, respawns, array1OriginalLength, array2.Length);

        respawns = gameObject.GetComponent<TerrainManager>().GetBorderTiles();



        if (respawns.Count > 0)
        {
            int randomIndexLocations = UnityEngine.Random.Range(0, respawns.Count);
            GameObject piso = respawns[randomIndexLocations];


            Vector3 ground = new Vector3(respawns[randomIndexLocations].transform.position.x, 0, respawns[randomIndexLocations].transform.position.z);


            GameObject go = Instantiate(ChooseRandomEnemy(), ground, Quaternion.identity);
            go.GetComponent<EnemyBase>().gameStateObject = gameObject;
            Vector3 targetPosition = new Vector3(targetGameObject.transform.position.x, transform.position.y, targetGameObject.transform.position.z);
            go.transform.LookAt(targetPosition);

            if (!piso.GetComponent<TerrainTile>().isActiveTile)
            {

                go.GetComponent<EnemyBase>().SetEnable(false);
            }

            //go.GetComponent<EnemyBase>().SetBaseVelocity(baseSpeed);

            return go;


        }

        return null;
    }
}
