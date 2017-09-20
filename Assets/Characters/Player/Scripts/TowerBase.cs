using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerBase : MonoBehaviour
{
    public int maxLife = 3;

    public List<GameObject> towerParts = new List<GameObject>();
    void Start()
    {
        if (transform.gameObject.tag == "towerAll")
        {
            foreach (Transform child in transform)
            {
                if(child.tag != "towerIgnore")
                {
                    towerParts.Add(child.gameObject);
                }

            }
        }

        GameObject cannon = GameObject.FindGameObjectWithTag("Player");
        if (cannon != null)
        {
            towerParts.Add(cannon);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DecreaseLife()
    {
        maxLife--;

    }

    void OnGUI()
    {
        if (maxLife <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2, 0, 500f, 500f), "Perdiste");
            SceneManager.LoadScene("main");
        }
    }


}
