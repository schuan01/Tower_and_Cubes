using UnityEngine;
using UnityEngine.AI;
public class EnemyBase : MonoBehaviour
{

    // Use this for initialization


    public int enemyLife = 1;


    private float timeBetweenCheck = 0.1f;

    private GameObject piso = null;

    public GameObject gameStateObject;

    public bool isEnemyActive = true;

    public float maxSpeed = 0.0f;

    public int coinReward = 1;

    private bool isFreeze = false;

    public Material freezeMaterial;




    internal virtual void Start()
    {

        gameStateObject.GetComponent<EnemiesManager>().AddEnemyToList(gameObject);

        InvokeRepeating("ChangeStateByTile", 0, timeBetweenCheck);//A partir del segundo 0, cada 0.1 segundos

        GetComponent<NavMeshAgent>().speed = maxSpeed;

    }

    // Update is called once per frame
    void Update()
    {

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
    public virtual void ChangeStateByTile()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            piso = hit.transform.gameObject;
            if (piso != null && piso.GetComponent<TerrainTile>() != null && !piso.GetComponent<TerrainTile>().isActiveTile)
            {
                SetEnable(false);

            }
            else if (piso != null && piso.GetComponent<TerrainTile>() != null && piso.GetComponent<TerrainTile>().isActiveTile)
            {
                SetEnable(true);

            }
        }
    }

    public virtual void DecreseLife()
    {
        enemyLife -= 1;
        if (enemyLife == 0)
        {
            DestroyEnemy();
        }


    }

    public virtual void DestroyEnemy()
    {
        gameStateObject.GetComponent<EnemiesManager>().DestroyEnemy(gameObject, coinReward);
        Destroy(gameObject);


    }

    public virtual void DestroyEnemyWithoutScore()
    {
        gameStateObject.GetComponent<EnemiesManager>().DestroyEnemyWithoutScore(gameObject);
        Destroy(gameObject);


    }

    public void FreezeEnemy()
    {
        if (!isFreeze)
        {
            isFreeze = true;
            GetComponent<NavMeshAgent>().speed -= GetComponent<NavMeshAgent>().speed * 0.7f;

            Material[] mats = GetComponent<Renderer>().materials;
            for (int i = 0; i < mats.Length; i++)
            {

                if (mats[i].name.Contains("Marron") || mats[i].name.Contains("Negro") || mats[i].name.Contains("Gris"))
                {

                    mats[i] = freezeMaterial;

                }
            }

            GetComponent<Renderer>().materials = mats;
        }
    }




}
