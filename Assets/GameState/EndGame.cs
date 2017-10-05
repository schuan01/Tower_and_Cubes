using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {

	public Canvas finalCanvas;
	public Text textFinal;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("main");
	}

	public void ShowEndGamePanel()
	{
		finalCanvas.enabled = true;

		GetComponent<PauseGame>().Pause();
		textFinal.text = GetComponent<ScoreCounter>().score.ToString();
	}
}
