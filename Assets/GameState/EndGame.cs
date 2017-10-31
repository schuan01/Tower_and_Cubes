using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGame : MonoBehaviour
{

    public Canvas finalCanvas;
    public Text textFinal;

    public Text highScoreText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        GetComponent<PauseGame>().Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowEndGamePanel()
    {
        finalCanvas.enabled = true;

        GetComponent<PauseGame>().Pause();
        textFinal.text = GetComponent<ScoreCounter>().score.ToString();
        if (GetComponent<MySceneManager>().isMainScene)
        {
            if (GetComponent<SaveGameManager>().savegameAll.GetHighScoreClassic() < GetComponent<ScoreCounter>().score)
            {
                GetComponent<SaveGameManager>().savegameAll.SetHighScoreClassic(GetComponent<ScoreCounter>().score);
				GetComponent<SaveGameManager>().SaveGame();
            }

            highScoreText.text = GetComponent<SaveGameManager>().savegameAll.GetHighScoreClassic().ToString();
        }
        else
        {
            if (GetComponent<SaveGameManager>().savegameAll.GetHighScoreCross() < GetComponent<ScoreCounter>().score)
            {
                GetComponent<SaveGameManager>().savegameAll.SetHighScoreCross(GetComponent<ScoreCounter>().score);
				GetComponent<SaveGameManager>().SaveGame();
            }

            highScoreText.text = GetComponent<SaveGameManager>().savegameAll.GetHighScoreCross().ToString();
        }


    }

    public void EndTheGame()
    {
        ShowEndGamePanel();
    }
}
