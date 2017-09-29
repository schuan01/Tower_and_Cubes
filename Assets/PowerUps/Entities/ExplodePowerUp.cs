using UnityEngine.UI;
using UnityEngine;

public class ExplodePowerUp : BasePowerUp {

	public float timeToWaitPower = 10.0f;
    public float timeLapsed;

    public bool isPowerEnable = false;
	void Start () {
		timeLapsed = 10;
        coinCost = 10;
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLapsed += Time.deltaTime;

        if (timeLapsed >= timeToWaitPower && isPowerEnable == false)
        {
            isPowerEnable = true;

        }

        if (isPowerEnable && !executeButton.interactable)
        {
            executeButton.interactable = true;
        }
	}

	public void Execute()
	{
		if (isPowerEnable)
        {

            foreach (GameObject g in gameObject.GetComponent<EnemiesManager>().lstEnemies)
            {
                if (g != null)
                {
                    g.GetComponent<EnemyBase>().DestroyEnemy();
                }
            }

            isPowerEnable = false;
            executeButton.interactable = false;
            timeLapsed = 0;
        }
	}
}
