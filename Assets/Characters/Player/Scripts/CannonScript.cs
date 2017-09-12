using System;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public List<GameObject> listCameras = new List<GameObject>();
    public GameObject cameraPos_parent;

    private int currentCameraIndex = -1;

    public float lifetime_bullet = 2.0f;
    public float secondsToWaitShoot = 1.0f;
    private float timePassed = 0.0f;

    private bool supportTouch = true;



    void Start()
    {
        timePassed = 1.0f;//Para que pueda arrancar disparando}

        //check if our current system info equals a desktop
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            //we are on a desktop device, so don't use touch
            supportTouch = false;
        }
        //if it isn't a desktop, lets see if our device is a handheld device aka a mobile device
        else if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            //we are on a mobile device, so lets use touch input
            supportTouch = true;
        }

        if (cameraPos_parent != null)
        {
            foreach (Transform child in cameraPos_parent.transform)
            {
                listCameras.Add(child.gameObject);
            }

            currentCameraIndex = listCameras.Count - 1;//arranca en ultimo indice
        }
    }

    //float distance = 10.0f;
    public GameObject prefab;
    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;


        if (timePassed >= secondsToWaitShoot)
        {
            if (supportTouch)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    timePassed = 0.0f;

                    Vector3 myTransform = transform.forward;

                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    RaycastHit Hit;
                    //if(Physics.SphereCast(Input.GetTouch(0).position, 1.0f, direction, out Hit))
                    if (Physics.Raycast(ray, out Hit, 1000))
                    {

                        GameObject piso = Hit.transform.gameObject;
                        if ((piso != null) && (piso.tag.Contains("terrainQuad_On") || piso.tag.Contains("terrainQuad_Border_On")) || piso.tag.Contains("enemy"))
                        {
                            transform.LookAt(Hit.point, Vector3.down);
                            GameObject newProjectile = Instantiate(prefab, transform.GetChild(1).position, Quaternion.identity) as GameObject;
                            newProjectile.transform.LookAt(Hit.point);
                            newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2000);

                            Destroy(newProjectile, lifetime_bullet);
                        }


                    }



                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {

                    timePassed = 0.0f;

                    Vector3 myTransform = transform.forward;

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit Hit;
                    Vector3 direction = transform.TransformDirection(Vector3.forward);
                    //if(Physics.SphereCast(ray.origin, 1, ray.direction, out Hit))
                    if (Physics.Raycast(ray, out Hit, 1000))
                    {
                        //Debug.DrawRay(new Vector3(0,100,0),ray.direction,Color.red,10);
                        GameObject piso = Hit.transform.gameObject;
                        if ((piso != null) && (piso.tag.Contains("terrainQuad_On") || piso.tag.Contains("terrainQuad_Border_On")) || piso.tag.Contains("enemy"))
                        {
                            transform.LookAt(Hit.point, Vector3.down);
                            GameObject newProjectile = Instantiate(prefab, transform.GetChild(1).position, Quaternion.identity) as GameObject;
                            newProjectile.transform.LookAt(Hit.point);
                            newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2000);

                            Destroy(newProjectile, lifetime_bullet);
                        }


                    }



                }
            }
        }


        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            
        }*/



    }

    public void changeCameraPositionLeft()
    {
        if (listCameras.Count > 0)
        {
            currentCameraIndex++;
            if(currentCameraIndex > listCameras.Count -1)
            {
                currentCameraIndex = 0;
            }
            GameObject nuevaPos = listCameras[currentCameraIndex];
            

            Camera.main.transform.position = nuevaPos.transform.position;
            Quaternion rot = Camera.main.transform.rotation;
            Camera.main.transform.Rotate(rot.x,90,rot.z,Space.World);
            
            //Camera.main.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
            GameObject terreno = GameObject.FindGameObjectWithTag("terrainAll");
            //terreno.GetComponent<TerrainBase>().ChangeClickableTiles(true);



        }
    }

    public void changeCameraPositionRight()
    {
        if (listCameras.Count > 0)
        {
            currentCameraIndex--;
            if(currentCameraIndex < 0)
            {
                currentCameraIndex = listCameras.Count - 1;//Ultimo indice
            }

            GameObject nuevaPos = listCameras[currentCameraIndex];
            Debug.Log(nuevaPos.name);

            Camera.main.transform.position = nuevaPos.transform.position;
            Quaternion rot = Camera.main.transform.rotation;
            Camera.main.transform.Rotate(rot.x,-90,rot.z,Space.World);
            
            //Camera.main.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
            GameObject terreno = GameObject.FindGameObjectWithTag("terrainAll");
            //terreno.GetComponent<TerrainBase>().ChangeClickableTiles(true);



        }
    }


}
