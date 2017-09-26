
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBase : MonoBehaviour
{

    // Use this for initialization



    public bool isStatic = false;

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

    public IEnumerator SplitMesh(bool destroy)
    {

        if (GetComponent<MeshFilter>() == null || GetComponent<SkinnedMeshRenderer>() == null)
        {
            yield return null;
        }

        if (GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }

        Mesh M = new Mesh();
        if (GetComponent<MeshFilter>())
        {
            M = GetComponent<MeshFilter>().mesh;
        }
        else if (GetComponent<SkinnedMeshRenderer>())
        {
            M = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        }

        Material[] materials = new Material[0];
        if (GetComponent<MeshRenderer>())
        {
            materials = GetComponent<MeshRenderer>().materials;
        }
        else if (GetComponent<SkinnedMeshRenderer>())
        {
            materials = GetComponent<SkinnedMeshRenderer>().materials;
        }

        Vector3[] verts = M.vertices;
        Vector3[] normals = M.normals;
        Vector2[] uvs = M.uv;
        for (int submesh = 0; submesh < M.subMeshCount; submesh++)
        {

            int[] indices = M.GetTriangles(submesh);

            for (int i = 0; i < indices.Length; i += 3)
            {
                Vector3[] newVerts = new Vector3[3];
                Vector3[] newNormals = new Vector3[3];
                Vector2[] newUvs = new Vector2[3];
                for (int n = 0; n < 3; n++)
                {
                    int index = indices[i + n];
                    newVerts[n] = verts[index];
                    newUvs[n] = uvs[index];
                    newNormals[n] = normals[index];
                }

                Mesh mesh = new Mesh();
                mesh.vertices = newVerts;
                mesh.normals = newNormals;
                mesh.uv = newUvs;

                mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

                GameObject GO = new GameObject("Triangle " + (i / 3));
                GO.layer = LayerMask.NameToLayer("Particle");
                GO.transform.position = transform.position;
                GO.transform.rotation = transform.rotation;
                GO.AddComponent<MeshRenderer>().material = materials[submesh];
                GO.AddComponent<MeshFilter>().mesh = mesh;
                GO.AddComponent<BoxCollider>();
                Vector3 explosionPos = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(0f, 0.5f), transform.position.z + Random.Range(-0.5f, 0.5f));
                GO.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(300, 500), explosionPos, 5);
                Destroy(GO, 5 + Random.Range(0.0f, 5.0f));
            }
        }

        GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(1.0f);
        if (destroy == true)
        {
            Destroy(gameObject);
        }

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
