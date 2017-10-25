using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartClassicGame()
    {
        SceneManager.LoadScene("main");
    }

    public void StartCrossGame()
    {
        SceneManager.LoadScene("desert_scene");

    }

    public void ExitGame()
    {
        Application.Quit();

    }
}
