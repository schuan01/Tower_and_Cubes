
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBase : MonoBehaviour
{

    // Use this for initialization


    private int enemyLife = 1;
    public float timeBeforeExplode = 3.0f;

    private float timeBetweenCheck = 0.1f;
    
    private bool isExploding = false;
    private GameObject piso = null;

    

    
    void Start()
    {

        if (gameObject.tag.Contains("enemy_normal"))
        {
            enemyLife = 1;
        }
        else if (gameObject.tag.Contains("enemy_explosive"))
        {
            enemyLife = 1;
        }
        else if (gameObject.tag.Contains("enemy_giant"))
        {
            enemyLife = 3;
        }

        InvokeRepeating("ChangeTagByTile", 2, timeBetweenCheck);//A partir del segundo 2, cada 0.5 segundos
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameObject.tag.Contains("enemy_explosive"))
        {
            timeBeforeExplode -= Time.deltaTime;
            if (timeBeforeExplode <= 0 && isExploding == false)
            {
                isExploding = true;
                DestroyEnemyWithTile();

            }
        }
    }

    public void StopMovement()
    {
        GetComponent<NavMeshAgent>().speed = 0;
    }

    public void SetBaseVelocity(float multiplier)
    {
         GetComponent<NavMeshAgent>().speed = GetComponent<NavMeshAgent>().speed + multiplier;
    }
    private void ChangeTagByTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            piso = hit.transform.gameObject;
            if (piso != null && piso.tag.Contains("Off") && !gameObject.tag.Contains("off"))
            {
                gameObject.tag = gameObject.tag + "_off";
            }
            else if (piso != null && piso.tag.Contains("On"))
            {
                gameObject.tag = gameObject.tag.Replace("_off", "");//Sea el On o el off
            }
        }
    }

    public void DecreseLife()
    {
        enemyLife -= 1;
        if (enemyLife == 0)
        {
            DestroyEnemy();
        }


    }

    void DestroyEnemy()
    {

        //StartCoroutine(SplitMesh(true));
        GameObject go = GameObject.FindGameObjectWithTag("gameState");
        go.GetComponent<ScoreCounter>().ChangeScore();
        go.GetComponent<WaveGenerator>().ChangeEnemiesLeft();
        Destroy(gameObject);


    }

    void DestroyEnemyWithTile()
    {
        if (gameObject.tag.Contains("enemy_explosive") && isExploding == true)
        {
            //isExploding = false;
            DestroyCurrentTile();
        }

        //StartCoroutine(SplitMesh(true));
        Destroy(gameObject);
        GameObject go = GameObject.FindGameObjectWithTag("gameState");
        go.GetComponent<WaveGenerator>().ChangeEnemiesLeft();


    }

    public void DestroyCurrentTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            GameObject go = hit.transform.gameObject;
            if (go != null && go.tag.Contains("terrainQuad"))
            {
                go.transform.parent.gameObject.GetComponent<TerrainBase>().CheckBorders(go);
                go.transform.parent.gameObject.GetComponent<TerrainBase>().DestroyTile(go);
            }
        }

    }



}
