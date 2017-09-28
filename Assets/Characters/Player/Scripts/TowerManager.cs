using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {
public List<GameObject> lstTowerParts = new List<GameObject>();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPartToList(GameObject obj)
	{
		lstTowerParts.Add(obj);
	}

	public void RemovePartFromList(GameObject obj)
	{
		lstTowerParts.RemoveAll(g => g.GetInstanceID() == obj.GetInstanceID());
	}

	public void UpdatePartFromList(GameObject obj)
	{
		RemovePartFromList(obj);
		AddPartToList(obj);
	}
}
