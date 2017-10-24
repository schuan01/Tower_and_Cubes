
using UnityEngine;

public class ExplosiveEnemy : EnemyBase
{
    private bool isExploding = false;
    public float timeBeforeExplode = 3.0f;
    internal override void Start()
    {
        base.enemyLife = 1;
        base.maxSpeed = 1.3f;
        if (gameObject.tag.Contains("enemy_explosive_static"))
        {
            base.maxSpeed = 0;
        }
        base.Start();
    }

    void Update()
    {

        timeBeforeExplode -= Time.deltaTime;
        if (timeBeforeExplode <= 0 && isExploding == false)
        {
            isExploding = true;
            DestroyEnemyWithTile();

        }

    }

    void DestroyEnemyWithTile()
    {
        if (isExploding == true)
        {
            DestroyCurrentTile();
            gameStateObject.GetComponent<EnemiesManager>().DestroyEnemyWithoutScore(gameObject);
            /*GetComponent<AudioSource>().clip = popSound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();*/
            Destroy(gameObject);
        }
    }



    void DestroyCurrentTile()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1000))
        {
            GameObject go = hit.transform.gameObject;
            if (go != null && go.tag.Contains("terrainQuad"))
            {
                
                go.transform.parent.gameObject.GetComponent<TerrainBase>().CheckBorders(go);
               

                go.transform.parent.gameObject.GetComponent<TerrainBase>().DestroyTile(go);

            }

        }
        else
        {
            
            Debug.Log("Cayo en ELSE");
        }

    }


}
