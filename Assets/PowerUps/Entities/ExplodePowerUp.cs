
using UnityEngine;
public class ExplodePowerUp : BasePowerUp
{

    internal override void Start()
    {
        base.Start();
        powerVFXInstance = Instantiate(powerVFXPrefab,powerVFXLocation,Quaternion.identity);
        powerVFXInstance.gameObject.transform.Rotate(new Vector3(90,0,0));
        powerVFXInstance.Stop();

    }

    void Awake()
    {
        timeLapsed = 10;
        coinCost = 1;
        timeToWaitPower = 10.0f;
        powerName = "Explode_all_Enemies";
        powerButtonName = "Explotar";

    }


    public void Execute()
    {
        if (isPowerEnable)
        {
            if(powerVFXPrefab != null && powerVFXInstance != null)
            {
                powerVFXInstance.Play();
            }

            /*foreach (GameObject g in gameObject.GetComponent<EnemiesManager>().lstEnemies)
            {
                if (g != null)
                {
                    g.GetComponent<EnemyBase>().DestroyEnemy();
                }
            }*/

            isPowerEnable = false;
            executeButton.interactable = false;
            timeLapsed = 0;
        }
    }
}
