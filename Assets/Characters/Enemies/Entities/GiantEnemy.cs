

public class GiantEnemy : EnemyBase {

	// Use this for initialization
	 internal override void Start()
    {
        base.enemyLife = 3;
		base.maxSpeed = 0.7f;
		base.coinReward = 3;
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
