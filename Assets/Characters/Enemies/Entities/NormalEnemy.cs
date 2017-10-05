

public class NormalEnemy : EnemyBase {

	// Use this for initialization
	internal override void Start () {
		base.enemyLife = 1;
		base.maxSpeed = 1.3f;
		base.Start();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
