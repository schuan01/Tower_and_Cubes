using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    // Use this for initialization

    public List<GameObject> listCameras = new List<GameObject>();
    public GameObject cameraPos_parent;

    private int currentCameraIndex = -1;

    public GameObject terrainAll;

    public bool isMoving = false;

    public float cameraTransitionTime = 0.4f;
    void Start()
    {

        if (cameraPos_parent != null)
        {
            foreach (Transform child in cameraPos_parent.transform)
            {
                listCameras.Add(child.gameObject);
            }

            currentCameraIndex = listCameras.Count - 1;//arranca en ultimo indice
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCameraPositionLeft()
    {

        if (listCameras.Count > 0 && !isMoving)
        {
            currentCameraIndex++;
            if (currentCameraIndex > listCameras.Count - 1)
            {
                currentCameraIndex = 0;
            }
            GameObject nuevaPos = listCameras[currentCameraIndex];
            terrainAll.GetComponent<TerrainBase>().ChangeClickableTiles(nuevaPos);

            StartCoroutine(MoveObject(Camera.main.transform,
                       Camera.main.transform.position,
                       nuevaPos.transform.position,
                       Camera.main.transform.rotation,
                       nuevaPos.transform.rotation,
                       cameraTransitionTime));


      



        }
    }

    public void changeCameraPositionRight()
    {
        if (listCameras.Count > 0 && !isMoving)
        {
            currentCameraIndex--;
            if (currentCameraIndex < 0)
            {
                currentCameraIndex = listCameras.Count - 1;//Ultimo indice
            }

            GameObject nuevaPos = listCameras[currentCameraIndex];
            terrainAll.GetComponent<TerrainBase>().ChangeClickableTiles(nuevaPos);
            StartCoroutine(MoveObject(Camera.main.transform,
                        Camera.main.transform.position,
                        nuevaPos.transform.position,
                        Camera.main.transform.rotation,
                        nuevaPos.transform.rotation,
                        cameraTransitionTime));

       




        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, Quaternion startRot, Quaternion endRot, float time)
    {
        isMoving = true; // MoveObject started
        float i = 0;
        float rate = 1 / time;
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            thisTransform.rotation = Quaternion.Slerp(startRot, endRot, i);
            yield return 0;
        }
        isMoving = false; // MoveObject ended
    }
}
