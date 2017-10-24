using UnityEngine;
using UnityEngine.AI;

public class IceBlastScript : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {

        if(other.GetComponent<EnemyBase>() != null)
		{
			other.GetComponent<EnemyBase>().FreezeEnemy();
		}
    }

}
