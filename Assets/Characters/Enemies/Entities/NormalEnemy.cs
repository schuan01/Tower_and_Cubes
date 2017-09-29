using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : EnemyBase {

	// Use this for initialization
	internal override void Start () {
		base.enemyLife = 1;
		base.Start();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
