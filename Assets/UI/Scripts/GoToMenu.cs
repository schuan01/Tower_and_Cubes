﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenMenu()
	{
		GetComponent<PauseGame>().Pause();
		SceneManager.LoadScene("mainMenu_scene");
	}
	
}
