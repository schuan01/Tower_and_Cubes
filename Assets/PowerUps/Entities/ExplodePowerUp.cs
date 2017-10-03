
using UnityEngine;
public class ExplodePowerUp : BasePowerUp
{


    public float timeLapsed;

    public bool isPowerEnable = false;
    void Start()
    {

        if (usageCountLeft <= 0)
        {

            executeButton.interactable = false;
            isPowerEnable = false;
        }
    }

    void Awake()
    {
        timeLapsed = 10;
        coinCost = 40;
        timeToWaitPower = 10.0f;
        powerName = "Explode_all_Enemies";
        powerButtonName = "Explotar";

    }

    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;

        if (timeLapsed >= timeToWaitPower && usageCountLeft > 0)
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
