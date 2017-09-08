using System;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public float speed;
    public float lifetime_bullet = 2.0f;
    public float secondsToWaitShoot = 1.0f;
    private float timePassed = 0.0f;

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
        timePassed = 1.0f;//Para que pueda arrancar disparando
    }

    //float distance = 10.0f;
    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
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

        if (timePassed >= secondsToWaitShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {

                timePassed = 0.0f;



                Vector3 myTransform = transform.forward;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit Hit;
                if (Physics.Raycast(ray, out Hit, 1000))
                {

                    GameObject piso = Hit.transform.gameObject;
                    if (piso != null && piso.tag.Contains("terrainQuad"))
                    {
                        //piso.transform.parent.gameObject.GetComponent<TerrainBase>().CheckBorders(piso);
                        //piso.transform.parent.gameObject.GetComponent<TerrainBase>().DestroyTile(piso);
                        //GameObject[,] terrainAll = piso.transform.parent.gameObject.GetComponent<TerrainBase>().GetArrayTerrain();
                        //Destroy(piso);
                    }
                    GameObject newProjectile = Instantiate(prefab, transform.GetChild(1).position, Quaternion.identity) as GameObject;
                    newProjectile.transform.LookAt(Hit.point);
                    newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2000);

                    Destroy(newProjectile, lifetime_bullet);

                    //Quaternion rot = Quaternion.LookRotation(Hit.point,Vector3.up);
                    //transform.rotation = rot;
                    transform.LookAt(Hit.point, Vector3.down);


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


}
