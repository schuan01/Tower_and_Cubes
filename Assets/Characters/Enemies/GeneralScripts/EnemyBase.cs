
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

    public GameObject gameStateObject;

    public bool isEnemyActive = true;

    

    
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

        gameStateObject.GetComponent<EnemiesManager>().AddEnemyToList(gameObject);

        InvokeRepeating("ChangeStateByTile", 2, timeBetweenCheck);//A partir del segundo 2, cada 0.5 segundos
        
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

    public void SetEnable(bool val)
    {
        isEnemyActive = val;
        gameStateObject.GetComponent<EnemiesManager>().UpdateEnemyFromList(gameObject);
    }


    public void StopMovement()
    {
        GetComponent<NavMeshAgent>().speed = 0;
    }

    public void SetBaseVelocity(float multiplier)
    {
         GetComponent<NavMeshAgent>().speed = GetComponent<NavMeshAgent>().speed + multiplier;
    }
    private void ChangeStateByTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            piso = hit.transform.gameObject;
            if (piso != null && !piso.GetComponent<TerrainTile>().isActiveTile && isEnemyActive)
            {
                SetEnable(false);
            }
            else if (piso != null && piso.GetComponent<TerrainTile>().isActiveTile)
            {
                SetEnable(true);
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

    public void DestroyEnemy()
    {

        gameStateObject.GetComponent<EnemiesManager>().DestroyEnemy(gameObject);
        Destroy(gameObject);


    }

    void DestroyEnemyWithTile()
    {
        if (gameObject.tag.Contains("enemy_explosive") && isExploding == true)
        {
            DestroyCurrentTile();
        }

        gameStateObject.GetComponent<EnemiesManager>().DestroyEnemyWithoutScore(gameObject);
        Destroy(gameObject);
        


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
