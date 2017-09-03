using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public float speed;

    void FixedUpdate()
    {
        /*Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Debug.Log(mousePosition.ToString());
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        //GetComponent<Rigidbody>().angularVelocity = 0;

        float input = Input.GetAxis("Vertical");
         GetComponent<Rigidbody>().AddForce(gameObject.transform.up * speed * input);*/
    }

    void Start()
    {

    }

    float distance = 10.0f;
    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = new Vector2();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Camera.main.pixelHeight - (Input.mousePosition.y*-1);
            Vector3 position = new Vector3(mousePos.x, mousePos.y, 10);
            Debug.Log("Posicion inicial:"+position); 
            position = Camera.main.ScreenToWorldPoint(position);
            transform.LookAt(position);
            Debug.Log("Posicion final:"+position); 


            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            position = Camera.main.ScreenToWorldPoint(position);
            GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
            go.transform.LookAt(position);
            Debug.Log(position); 
            GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000);
        }*/
        if (Input.GetMouseButtonDown(0))
        {



            Vector3 myTransform = transform.forward;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit, 1000))
            {
                
               Debug.DrawRay(transform.position, myTransform, Color.red);
               GameObject newProjectile = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
               newProjectile.transform.LookAt(Hit.point);
               newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1000);
                
            }



            /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            Vector3 targetPos;

            if (Physics.Raycast(ray, out Hit, 100))
            {


                Debug.DrawRay(transform.position, transform.position, Color.red);


            }
            targetPos = Hit.point;
            targetPos.y = (float)(transform.position.y + 1.4);
            targetPos.z -= 1;
            transform.LookAt(targetPos);

            Vector3 spawnPos = new Vector3((float)(transform.position.x), (float)(transform.position.y + 1.4), transform.position.z);
            GameObject go = Instantiate(prefab, spawnPos,Quaternion.LookRotation(targetPos));
            go.transform.LookAt(targetPos);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 20);*/
            /*Vector3 spawnPos = new Vector3((float)(transform.position.x), (float)(transform.position.y + 1.3), transform.position.z);
            GameObject abil = (GameObject)Instantiate(Resources.Load("fireball"), spawnPos, Quaternion.LookRotation(targetPos));
            abil.GetComponent<Fireball>().Ignore = "player";
            abil.transform.LookAt(targetPos);
            abil.rigidbody.AddForce(abil.transform.forward * ability.Speed);*/
        }



    }
}
