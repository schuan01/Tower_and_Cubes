using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour {

	
	int score;
	public Text countText;
	void Start () {
		score = 0;
		countText.text = "Puntaje: "+ score.ToString();
		
	}
	
	public void ChangeScore()
	{
		score++;
		countText.text = "Puntaje: "+ score.ToString();
	}
}
