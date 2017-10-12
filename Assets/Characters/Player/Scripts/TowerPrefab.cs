using UnityEngine;

public class TowerPrefab : MonoBehaviour
{

    public int maxLife = 3;

    public GameObject player;

    public GameObject gameStateObject;

	public GameObject towerMedium;
	public GameObject towerSmall;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseLife()
    {
        maxLife--;
        if (maxLife <= 0)
        {
            gameStateObject.GetComponent<EndGame>().EndTheGame();

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("enemy"))
        {
            Destroy(other.gameObject);
            DecreaseLife();
            gameStateObject.GetComponent<WaveGenerator>().ChangeEnemiesLeft();
			ChangeTowerSize();
        }
    }

	private void ChangeTowerSize()
	{
		if(maxLife == 2)
		{
			//Reemplazo el prefab actual por el nuevo
			GetComponent<MeshRenderer>().enabled = false;//Oculto el actual
			GameObject go = Instantiate(towerMedium,transform.position,transform.rotation);
			go.transform.parent = gameObject.transform.parent;
			go.GetComponent<TowerPrefab>().maxLife = maxLife;
			go.GetComponent<TowerPrefab>().gameStateObject = gameStateObject;
			go.GetComponent<TowerPrefab>().player = player;
			Transform [] t = go.GetComponentsInChildren<Transform>();
			go.GetComponent<TowerPrefab>().player.transform.position = t[1].position;

			Destroy(gameObject);//Destruyo el actual

			
		}

		if(maxLife == 1)
		{
			//Reemplazo el prefab actual por el nuevo
			GetComponent<MeshRenderer>().enabled = false;//Oculto el actual
			GameObject go = Instantiate(towerSmall,transform.position,transform.rotation);
			go.transform.parent = gameObject.transform.parent;
			go.GetComponent<TowerPrefab>().maxLife = maxLife;
			go.GetComponent<TowerPrefab>().gameStateObject = gameStateObject;
			go.GetComponent<TowerPrefab>().player = player;
			Transform [] t = go.GetComponentsInChildren<Transform>();
			go.GetComponent<TowerPrefab>().player.transform.position = t[1].position;

			Destroy(gameObject);//Destruyo el actual

			
		}
	}
}
