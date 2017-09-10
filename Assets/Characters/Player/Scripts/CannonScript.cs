using System;
using UnityEngine;

public class CannonScript : MonoBehaviour
{


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
                    RaycastHit Hit;
                    if (Physics.Raycast(ray, out Hit, 1000))
                    {

                        GameObject piso = Hit.transform.gameObject;
                        if (piso != null && piso.tag.Contains("terrainQuad") || piso.tag.Contains("enemy"))
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
                    if (Physics.Raycast(ray, out Hit, 1000))
                    {

                        GameObject piso = Hit.transform.gameObject;
                        if (piso != null && piso.tag.Contains("terrainQuad_On") || piso.tag.Contains("enemy"))
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



    }


}
