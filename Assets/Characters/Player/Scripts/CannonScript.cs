using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonScript : MonoBehaviour
{

    public float lifetime_bullet = 2.0f;
    public float secondsToWaitShoot = 1.0f;
    public float waitToShootDecreser = 0.03f;
    private float timePassed = 0.0f;

    public float bulletSpeed = 2500;

    private bool supportTouch = true;

    public GameObject bullet;

    public GameObject gameStateObject;

    private int fingerID = -1;

    public bool allowToRotateCamera = true;

    void Awake()
    {
#if !UNITY_EDITOR
            fingerID = 0; 
#endif
    }
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

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject(fingerID))
        {

            return;
        }

        timePassed += Time.deltaTime;



        if (supportTouch)
        {
            if (Input.touchCount > 0)
            {

                if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {

                    ShootToLocation(Input.GetTouch(0).position);


                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {

                ShootToLocation(Input.mousePosition);

            }
        }
    }

    private void ShootToLocation(Vector3 inputPosition)
    {
        int layerMask = 1 << 3;
        layerMask = ~layerMask;


        Vector3 myTransform = transform.forward;

        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit, 1000, layerMask))
        {
            if (timePassed >= secondsToWaitShoot)
            {
                timePassed = 0.0f;
                GameObject piso = Hit.transform.gameObject;
                if (((piso != null) && (piso.tag.Contains("terrainQuad") && (piso.GetComponent<TerrainTile>().isActiveTile)) || (piso.tag.Contains("enemy") && piso.GetComponent<EnemyBase>().isEnemyActive)))
                {
                    Vector3 targetPosition = new Vector3(Hit.point.x, transform.position.y, Hit.point.z);
                    transform.LookAt(targetPosition);
                    GameObject newProjectile = Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity) as GameObject;
                    newProjectile.transform.LookAt(Hit.point);
                    newProjectile.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed);

                    Destroy(newProjectile, lifetime_bullet);
                }
            }
        }
        else
        {
            if (allowToRotateCamera)
            {
                if (inputPosition.x < Screen.width / 2)
                {
                    gameStateObject.GetComponent<MoveCamera>().changeCameraPositionLeft();
                }

                if (inputPosition.x > Screen.width / 2)
                {
                    gameStateObject.GetComponent<MoveCamera>().changeCameraPositionRight();
                }
            }
        }


    }

    public void ChangeShootInterval()
    {
        secondsToWaitShoot -= waitToShootDecreser;
    }




}
