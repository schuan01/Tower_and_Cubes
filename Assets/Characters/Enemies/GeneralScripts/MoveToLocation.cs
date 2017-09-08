using UnityEngine;
using UnityEngine.AI;

public class MoveToLocation : MonoBehaviour {

	public GameObject target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 des = target.transform.position;
		des.y = 0;
		agent.SetDestination(des);
		
	}
}
