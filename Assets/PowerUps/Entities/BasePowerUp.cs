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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

	public void DecreseUsageCountLeft()
	{
		usageCountLeft -= 1;
        if(usageCountLeft < 0)
        {
            usageCountLeft = 0;
        }
	}
}
