using UnityEngine;
using UnityEngine.AI;

public class FreezePowerUp : BasePowerUp
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
        coinCost = 50;
        timeToWaitPower = 10.0f;
        powerName = "Freeze_all_Enemies";
        powerButtonName = "Congelar";
        

    }

    // Update is called once per frame
    


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
                    g.GetComponent<NavMeshAgent>().speed -= g.GetComponent<NavMeshAgent>().speed * 0.7f;
                    Material[] mats = g.GetComponent<Renderer>().materials;
                    for (int i = 0; i < mats.Length; i++)
                    {

                        if (mats[i].name.Contains("Marron") || mats[i].name.Contains("Negro") || mats[i].name.Contains("Gris"))
                        {

                            mats[i] = GetComponent<PowerUpsManager>().freezeMaterial;
                            
                        }
                    }

                    g.GetComponent<Renderer>().materials = mats;
                }
            }*/

            isPowerEnable = false;
            executeButton.interactable = false;
            timeLapsed = 0;
        }
    }
}
