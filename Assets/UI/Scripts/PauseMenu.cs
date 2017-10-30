using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour {

	// Use this for initialization

	public Canvas panelPauseGame;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void OpenPauseMenu()
	{
		panelPauseGame.enabled = true;
		GetComponent<PauseGame>().Pause();
	}

	public void ClosePauseMenu()
	{
		panelPauseGame.enabled = false;
		GetComponent<PauseGame>().Pause();
	}
}
