using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerBase : MonoBehaviour
{
    public int maxLife = 3;

    public GameObject player;

    public GameObject gameStateObject;

    public GameObject nextPartToFall;
    void Start()
    {
        if (transform.gameObject.tag == "towerAll")
        {
            foreach (Transform child in transform)
            {
                TowerParts parts = child.GetComponent<TowerParts>();
                if (parts != null)
                {
                    if(child.gameObject.name == "tower_bot")
                    {
                        nextPartToFall = child.gameObject;
                    }
                    if (!child.GetComponent<TowerParts>().isIgnore)
                    {
                        gameStateObject.GetComponent<TowerManager>().AddPartToList(child.gameObject);
                    }
                }

            }
        }

        GameObject cannon = player;
        if (cannon != null)
        {
            gameStateObject.GetComponent<TowerManager>().AddPartToList(cannon);
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
