using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour {

	
	public int score;
	int currentWave;

	public Text countText;

	public Text waveText;

	public Text coinText;
	void Start () {
		score = 0;
		currentWave = 1;
		countText.text = score.ToString();
		waveText.text = "Horda: "+ currentWave.ToString();
		coinText.text = GetComponent<CoinsManager>().globalCoins.ToString();
		
	}
	
	public void ChangeScore()
	{
		score++;
		countText.text = score.ToString();
	}

	public void ChangeWave(int wave)
	{
		currentWave = wave;
		waveText.text = "Horda: "+ currentWave.ToString();
	}

	public void ChangeCoins()
	{
		coinText.text = GetComponent<CoinsManager>().globalCoins.ToString();
	}
}
