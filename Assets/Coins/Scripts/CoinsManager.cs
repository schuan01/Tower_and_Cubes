using UnityEngine;

[System.Serializable]
public class CoinsManager : MonoBehaviour {

	public int globalCoins = 100;
	void Start () {
		globalCoins = SaveLoad.LoadCoins();
		if(globalCoins == -1)
		{
			//Si es la primera vez
			globalCoins = 100;
			SaveLoad.SaveCoins(globalCoins);
		}
		GetComponent<ScoreCounter>().ChangeCoins();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IncreseCoins()
	{
		globalCoins += 1;
		SaveLoad.SaveCoins(globalCoins);
		GetComponent<ScoreCounter>().ChangeCoins();
	}

	public void DecreseCoins(int value)
	{
		globalCoins -= value;
		if(globalCoins < 0)
		{
			globalCoins = 0;
		}

		SaveLoad.SaveCoins(globalCoins);
		GetComponent<ScoreCounter>().ChangeCoins();
	}
}
