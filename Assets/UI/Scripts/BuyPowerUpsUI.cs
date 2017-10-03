using UnityEngine;
using UnityEngine.UI;
public class BuyPowerUpsUI : MonoBehaviour {

	
	public Canvas canvasBuyPowerUps;
	public Button btnExplodeCoin;
	public Text txtExplodeCount; 
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreseCountOfUsagesExplosive()
	{
		bool res = GetComponent<PowerUpsManager>().CalculateUsageLeft<ExplodePowerUp>();
		if(res)
		{
			txtExplodeCount.text = GetComponent<ExplodePowerUp>().usageCountLeft.ToString();
			
		}
	}

	public void OpenCanvas()
	{
		canvasBuyPowerUps.enabled = true;
		Time.timeScale = 0;
		btnExplodeCoin.GetComponentInChildren<Text>().text = GetComponent<ExplodePowerUp>().coinCost.ToString();
		txtExplodeCount.text = GetComponent<ExplodePowerUp>().usageCountLeft.ToString();
		
	}

	public void CloseCanvas()
	{
		canvasBuyPowerUps.enabled = false;
		Time.timeScale = 1;
	}
}
