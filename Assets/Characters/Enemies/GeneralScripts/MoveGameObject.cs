using UnityEngine;

public class MoveGameObject : MonoBehaviour
{

    public GameObject target;
    public float speed;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetGround = new Vector3(target.transform.position.x, 0.45f, target.transform.position.z);


        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetGround, step);

    }

    /*void OnCollisionEnter(Collider other)
    {

        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
        }

    }*/

	
}
