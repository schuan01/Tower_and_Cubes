using UnityEngine;
using UnityEngine.UI;
public class PowerUpsManager : MonoBehaviour
{

    public Button explodeButton;



    void Start()
    {


        //Para el Explosion
        GetPowersFromStart<ExplodePowerUp>();


        //---Para los siguientes Power Ups, hace lo mismo de arriba

        //---








    }


    public void ExplodeEnemies()//Explota todo los enemigos de la vuelta
    {

        if (GetComponent<ExplodePowerUp>().usageCountLeft > 0)
        {
            gameObject.GetComponent<ExplodePowerUp>().Execute();
            gameObject.GetComponent<ExplodePowerUp>().DecreseUsageCountLeft();
            gameObject.GetComponent<ExplodePowerUp>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<ExplodePowerUp>().powerButtonName + "(" + GetComponent<ExplodePowerUp>().usageCountLeft + ")";
            gameObject.GetComponent<SaveGameManager>().savegameAll.AddValueToUsages(gameObject.GetComponent<ExplodePowerUp>().powerName, gameObject.GetComponent<ExplodePowerUp>().usageCountLeft);
            GetComponent<SaveGameManager>().SaveGame();
        }



        /*if (GetComponent<ExplodePowerUp>().usageCountLeft <= GetComponent<CoinsManager>().globalCoins)
        {
            GetComponent<CoinsManager>().DecreseCoins(GetComponent<ExplodePowerUp>().coinCost);
            gameObject.GetComponent<ExplodePowerUp>().Execute();
        }*/

    }

    public bool CalculateUsageLeft<ClassType>() where ClassType : BasePowerUp, new()
    {
        //Resta las monedas y agrega uno a la lista
        //Guarda la partida
        if (gameObject.GetComponent<CoinsManager>().globalCoins >= gameObject.GetComponent<ClassType>().coinCost)
        {
            gameObject.GetComponent<ClassType>().usageCountLeft += 1;
            gameObject.GetComponent<CoinsManager>().DecreseCoins(gameObject.GetComponent<ClassType>().coinCost);
            gameObject.GetComponent<SaveGameManager>().savegameAll.AddValueToUsages(gameObject.GetComponent<ClassType>().powerName, gameObject.GetComponent<ClassType>().usageCountLeft);
            gameObject.GetComponent<SaveGameManager>().SaveGame();
            ChangeUsageCount<ClassType>();
            return true;
        }

        return false;



    }


    private void GetPowersFromStart<ClassType>() where ClassType : BasePowerUp, new()
    {

        gameObject.AddComponent<ClassType>();
        gameObject.GetComponent<ClassType>().executeButton = explodeButton;
        gameObject.GetComponent<ClassType>().usageCountLeft = gameObject.GetComponent<SaveGameManager>()
                                                                    .savegameAll
                                                                    .GetUsageFromPowerName(gameObject.GetComponent<ClassType>().powerName, gameObject.GetComponent<ClassType>().usageCountLeft);

        gameObject.GetComponent<ClassType>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<ClassType>().powerButtonName + "(" + GetComponent<ClassType>().usageCountLeft + ")";
        gameObject.GetComponent<SaveGameManager>().savegameAll.AddValueToUsages(gameObject.GetComponent<ClassType>().powerName, gameObject.GetComponent<ClassType>().usageCountLeft);
    }

    public void ChangeUsageCount<ClassType>() where ClassType : BasePowerUp, new()
    {
        gameObject.GetComponent<ClassType>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<ClassType>().powerButtonName + "(" + GetComponent<ClassType>().usageCountLeft + ")";

    }




}
