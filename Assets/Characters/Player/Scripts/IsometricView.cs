using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricView : MonoBehaviour {

	// Use this for initialization

	public Vector3 fixPosition = new Vector3(-45f, 0f, 0f); 

	void Start () {
	//	this.transform.rotation = Quaternion.LookRotation( Camera.main.transform.forward ) * Quaternion.Euler (fixPosition);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
