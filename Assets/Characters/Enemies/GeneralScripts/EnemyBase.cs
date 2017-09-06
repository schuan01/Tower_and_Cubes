
using UnityEngine;

public class EnemyBase : MonoBehaviour {

	// Use this for initialization

	private int enemyLife = 1;
	void Start () 
	{
		if(gameObject.tag == "enemy_normal")
		{
			enemyLife = 1;
		}
		else if(gameObject.tag == "enemy_explosive")
		{
			enemyLife = 1;
		}
		else if(gameObject.tag == "enemy_giant")
		{
			enemyLife = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyLife == 0)
		{
			DestroyEnemy();
		}
	}

	public void DecreseLife()
	{
		enemyLife -=1;
	}

	void DestroyEnemy()
	{
		Destroy(gameObject);
	}
}
