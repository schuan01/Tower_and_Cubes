
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    // Use this for initialization

    private int enemyLife = 1;
	private float timeBeforeExplode = 3.0f;
	private bool isExploding = false;
    void Start()
    {
        if (gameObject.tag == "enemy_normal")
        {
            enemyLife = 1;
        }
        else if (gameObject.tag == "enemy_explosive")
        {
            enemyLife = 1;
        }
        else if (gameObject.tag == "enemy_giant")
        {
            enemyLife = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
		if(gameObject.tag == "enemy_explosive")
		{
			timeBeforeExplode -= Time.deltaTime;
			if(timeBeforeExplode <= 0 && isExploding == false)
			{
				isExploding = true;
				DestroyEnemy();
				
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
		if(gameObject.tag == "enemy_explosive" && isExploding == true)
		{
			
			DestroyCurrentTile();
		}
		
        StartCoroutine(SplitMesh(true));
        //Destroy(gameObject);


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
        Debug.DrawRay(transform.position, -transform.up * 10,Color.red,10);
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            GameObject piso = hit.transform.gameObject;
            if (piso != null && piso.tag.Contains("terrainQuad"))
            {
                piso.transform.parent.gameObject.GetComponent<TerrainBase>().CheckBorders(piso);
                piso.transform.parent.gameObject.GetComponent<TerrainBase>().DestroyTile(piso);
                //GameObject[,] terrainAll = piso.transform.parent.gameObject.GetComponent<TerrainBase>().GetArrayTerrain();
                //Destroy(piso);
            }
        }

    }

}
