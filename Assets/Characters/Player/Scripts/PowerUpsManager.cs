
using UnityEngine;
using UnityEngine.UI;

public class PowerUpsManager : MonoBehaviour
{

    public float timeToWaitPower = 10.0f;
    public float timeLapsed;

    public Button explodeButton;

    public GameObject gameStateObject;



    public bool isPowerEnable = false;
    // Use this for initialization
    void Start()
    {
        timeLapsed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timeLapsed += Time.deltaTime;

        if (timeLapsed >= timeToWaitPower && isPowerEnable == false)
        {
            isPowerEnable = true;

        }

        if (isPowerEnable && !explodeButton.interactable)
        {
            explodeButton.interactable = true;
        }
    }

    public void ExplodeEnemies()//Explota todo los enemigos de la vuelta
    {

        if (isPowerEnable)
        {

            foreach (GameObject g in gameStateObject.GetComponent<EnemiesManager>().lstEnemies)
            {
                if (g != null)
                {
                    g.GetComponent<EnemyBase>().DestroyEnemy();
                }
            }

            isPowerEnable = false;
            explodeButton.interactable = false;
            timeLapsed = 0;
        }
    }

   
}
