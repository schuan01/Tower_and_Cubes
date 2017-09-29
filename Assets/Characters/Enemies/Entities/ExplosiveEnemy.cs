using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemy : EnemyBase
{
    private bool isExploding = false;
    internal override void Start()
    {
        base.enemyLife = 1;
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
            Destroy(gameObject);
        }
    }

    void DestroyCurrentTile()
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
