using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Contains("enemy"))//Mientras sea un enemigo
        {
			collision.gameObject.GetComponent<EnemyBase>().DecreseLife();
           
			Destroy(gameObject);//Destruid bala
        }



    }
}
