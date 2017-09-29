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

    public GameObject bullet;

    public GameObject terrainAll;





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

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 3;
        layerMask = ~layerMask;

        timePassed += Time.deltaTime;


        if (timePassed >= secondsToWaitShoot)
        {
            if (supportTouch)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {


                    }


                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                    {
                        timePassed = 0.0f;

                        Vector3 myTransform = transform.forward;

                        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                        RaycastHit Hit;
                        //if(Physics.SphereCast(Input.GetTouch(0).position, 1.0f, direction, out Hit))
                        if (Physics.Raycast(ray, out Hit, 1000, layerMask))
                        //if (Physics.Raycast(transform.position, transform.forward, out Hit, Mathf.Infinity, layerMask))
                        {

                            GameObject piso = Hit.transform.gameObject;
                            if (((piso != null) && (piso.tag.Contains("terrainQuad") && (piso.GetComponent<TerrainTile>().isActiveTile)) || (piso.tag.Contains("enemy") && piso.GetComponent<EnemyBase>().isEnemyActive)))
                            {
                                Vector3 targetPosition = new Vector3(Hit.point.x, transform.position.y, Hit.point.z);
                                ShootToLocation(targetPosition, Hit.point);
                            }


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
                    //Vector3 direction = transform.TransformDirection(Vector3.forward);
                    //if (Physics.Raycast(ray.origin, ray.direction, out Hit, Mathf.Infinity, layerMask))
                    if (Physics.Raycast(ray, out Hit, 1000, layerMask))
                    {
                        //Debug.DrawRay(new Vector3(0,100,0),ray.direction,Color.red,10);
                        GameObject piso = Hit.transform.gameObject;
                        if (((piso != null) && (piso.tag.Contains("terrainQuad") && (piso.GetComponent<TerrainTile>().isActiveTile) || (piso.tag.Contains("enemy") && piso.GetComponent<EnemyBase>().isEnemyActive))))
                        {
                            
                            Vector3 targetPosition = new Vector3(Hit.point.x, transform.position.y, Hit.point.z);
                            ShootToLocation(targetPosition, Hit.point);

                        }

                    }



                }
            }
        }






    }

    private void ShootToLocation(Vector3 targetPosition, Vector3 hitPoint)
    {
        transform.LookAt(targetPosition);
        //transform.LookAt(Hit.point);
        //transform.LookAt(ray.GetPoint(1000), Vector3.down);
        //transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        GameObject newProjectile = Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity) as GameObject;
        newProjectile.transform.LookAt(hitPoint);
        newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 2500);

        Destroy(newProjectile, lifetime_bullet);
    }

    public void changeCameraPositionLeft()
    {
        if (listCameras.Count > 0)
        {
            currentCameraIndex++;
            if (currentCameraIndex > listCameras.Count - 1)
            {
                currentCameraIndex = 0;
            }
            GameObject nuevaPos = listCameras[currentCameraIndex];


            Camera.main.transform.position = nuevaPos.transform.position;
            Quaternion rot = Camera.main.transform.rotation;
            Camera.main.transform.Rotate(0, 90, 0, Space.World);

            //Camera.main.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
            terrainAll.GetComponent<TerrainBase>().ChangeClickableTiles(nuevaPos);



        }
    }

    public void changeCameraPositionRight()
    {
        if (listCameras.Count > 0)
        {
            currentCameraIndex--;
            if (currentCameraIndex < 0)
            {
                currentCameraIndex = listCameras.Count - 1;//Ultimo indice
            }

            GameObject nuevaPos = listCameras[currentCameraIndex];

            Camera.main.transform.position = nuevaPos.transform.position;
            Quaternion rot = Camera.main.transform.rotation;
            Camera.main.transform.Rotate(0, -90, 0, Space.World);

            //Camera.main.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
            terrainAll.GetComponent<TerrainBase>().ChangeClickableTiles(nuevaPos);



        }
    }


}
