
using UnityEngine;
public class ExplodePowerUp : BasePowerUp
{

    internal override void Start()
    {
        base.Start();

    }

    void Awake()
    {
        timeLapsed = 10;
        coinCost = 100;
        timeToWaitPower = 10.0f;
        powerName = "Explode_all_Enemies";
        powerButtonName = "Explotar";

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
