using UnityEngine.UI;
using UnityEngine;

public class ExplodePowerUp : BasePowerUp
{

    public float timeToWaitPower = 10.0f;
    public float timeLapsed;

    public bool isPowerEnable = false;
    void Start()
    {
        timeLapsed = 10;
        coinCost = 40;

        if (coinCost > GetComponent<CoinsManager>().globalCoins)
        {

            executeButton.interactable = false;
            isPowerEnable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;

        if (timeLapsed >= timeToWaitPower && coinCost <= GetComponent<CoinsManager>().globalCoins)
        {
            isPowerEnable = true;
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
                    g.GetComponent<EnemyBase>().DestroyEnemyWithoutScore();
                }
            }

            isPowerEnable = false;
            executeButton.interactable = false;
            timeLapsed = 0;
        }
    }
}
