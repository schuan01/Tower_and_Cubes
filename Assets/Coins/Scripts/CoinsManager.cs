using UnityEngine;
public class CoinsManager : MonoBehaviour
{

    public int globalCoins = 100;
    void Start()
    {
        globalCoins = GetComponent<SaveGameManager>().savegameAll.GetGlobalCoins();
        if (globalCoins == -1)
        {
            //Si es la primera vez
            globalCoins = 100;
            GetComponent<SaveGameManager>().savegameAll.SetGlobalCoins(globalCoins);
            GetComponent<SaveGameManager>().SaveGame();
        }
        GetComponent<ScoreCounter>().ChangeCoins();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreseCoins(int coinIncrese)
    {
        globalCoins += coinIncrese;
        GetComponent<SaveGameManager>().savegameAll.SetGlobalCoins(globalCoins);
        GetComponent<SaveGameManager>().SaveGame();
        GetComponent<ScoreCounter>().ChangeCoins();
    }

    public void DecreseCoins(int value)
    {
        globalCoins -= value;
        if (globalCoins < 0)
        {
            globalCoins = 0;
        }

        GetComponent<SaveGameManager>().savegameAll.SetGlobalCoins(globalCoins);
        GetComponent<SaveGameManager>().SaveGame();
        GetComponent<ScoreCounter>().ChangeCoins();
    }
}
