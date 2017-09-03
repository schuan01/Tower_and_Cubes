using UnityEngine;

//Spawn an enemy in a random Point each 2 seconds
public class SpawnEnemy : MonoBehaviour {

	// Use this for initialization
	public GameObject respawnPrefab;
    public GameObject[] respawns;

	void Start () 
	{
		InvokeRepeating("SpawnRandomEnemy", 2, 2.0f);//A partir del segundo 2, cada 2 segundos
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnRandomEnemy()
	{
		
        respawns = GameObject.FindGameObjectsWithTag("randomPoint");//Obtiene todos los puntos

		if(respawns.Length > 0)
		{
			int randomIndex = Random.Range(0,respawns.Length);
			Vector3 ground = new Vector3(respawns[randomIndex].transform.position.x,0.45f,respawns[randomIndex].transform.position.z);	
    		Instantiate(respawnPrefab,ground, respawns[randomIndex].transform.rotation);
		}
	}
}
