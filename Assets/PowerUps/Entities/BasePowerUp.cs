using UnityEngine;
using UnityEngine.UI;

public class BasePowerUp : MonoBehaviour
{

    public int coinCost = 0;

    public int usageCountLeft = 1;

    public float timeToWaitPower = 0.0f;
    public Button executeButton;

    public string powerName;

    public string powerButtonName;

    public float timeLapsed;

    public bool isPowerEnable = false;

    public ParticleSystem powerVFXPrefab;

    public ParticleSystem powerVFXInstance;   

    public Vector3 powerVFXLocation; 

    internal virtual void Start()
    {
        if (usageCountLeft <= 0)
        {

            executeButton.interactable = false;
            isPowerEnable = false;
        }
    }


    // Update is called once per frame
    internal virtual void Update()
    {
        timeLapsed += Time.deltaTime;

        if (timeLapsed >= timeToWaitPower && usageCountLeft > 0)
        {
            isPowerEnable = true;
            executeButton.interactable = true;
        }
    }

    public void DecreseUsageCountLeft()
    {
        usageCountLeft -= 1;
        if (usageCountLeft < 0)
        {
            usageCountLeft = 0;
        }
    }
}
