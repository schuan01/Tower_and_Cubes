using UnityEngine;
public class CoinsManager : MonoBehaviour
{

    public int globalCoins = 100;//Empieza con 100

    public bool difRewardCost = false;
    public int countDifRewardCost = 0;
    void Start()
    {
        globalCoins = GetComponent<SaveGameManager>().savegameAll.GetGlobalCoins();
        if (globalCoins == -1)
        {

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
        if (!difRewardCost)
        {
            globalCoins += coinIncrese;
            GetComponent<SaveGameManager>().savegameAll.SetGlobalCoins(globalCoins);
            GetComponent<SaveGameManager>().SaveGame();
            GetComponent<ScoreCounter>().ChangeCoins();
        }
        else
        {
            countDifRewardCost++;
            if (countDifRewardCost == 10)
            {
                countDifRewardCost = 0;
                globalCoins += 1;
                GetComponent<SaveGameManager>().savegameAll.SetGlobalCoins(globalCoins);
                GetComponent<SaveGameManager>().SaveGame();
                GetComponent<ScoreCounter>().ChangeCoins();
            }
        }
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
