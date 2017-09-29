
using UnityEngine;


public class PauseGame : MonoBehaviour {

	// Use this for initialization

	public bool isPaused = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause(){

		if(isPaused)
		{
			Time.timeScale = 1;
			isPaused = false;
		}
		else
		{
			Time.timeScale = 0;
			isPaused = true;
		}

	}
}
