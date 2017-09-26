using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour {

	
	int score;
	int currentWave;
	public Text countText;

	public Text waveText;
	void Start () {
		score = 0;
		currentWave = 1;
		countText.text = "Puntaje: "+ score.ToString();
		waveText.text = "Oleada: "+ currentWave.ToString();
		
	}
	
	public void ChangeScore()
	{
		score++;
		countText.text = "Puntaje: "+ score.ToString();
	}

	public void ChangeWave(int wave)
	{
		currentWave = wave;
		waveText.text = "Oleada: "+ currentWave.ToString();
	}
}
