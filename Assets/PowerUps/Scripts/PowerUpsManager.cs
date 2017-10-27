using UnityEngine;
using UnityEngine.UI;
public class PowerUpsManager : MonoBehaviour
{

    public Button explodeButton;
    public Button freezeButton;

    public ParticleSystem iceParticlePrefab;

    public ParticleSystem fireParticlePrefab;

    public GameObject towerAll;


    void Start()
    {

        GetPowersFromStart<ExplodePowerUp>(explodeButton,fireParticlePrefab,towerAll.transform.position);
        GetPowersFromStart<FreezePowerUp>(freezeButton,iceParticlePrefab,towerAll.transform.position);

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


    }

    public void FreezeEnemies()//Explota todo los enemigos de la vuelta
    {

        if (GetComponent<FreezePowerUp>().usageCountLeft > 0)
        {

            gameObject.GetComponent<FreezePowerUp>().Execute();
            gameObject.GetComponent<FreezePowerUp>().DecreseUsageCountLeft();
            gameObject.GetComponent<FreezePowerUp>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<FreezePowerUp>().powerButtonName + "(" + GetComponent<FreezePowerUp>().usageCountLeft + ")";
            gameObject.GetComponent<SaveGameManager>().savegameAll.AddValueToUsages(gameObject.GetComponent<FreezePowerUp>().powerName, gameObject.GetComponent<FreezePowerUp>().usageCountLeft);
            GetComponent<SaveGameManager>().SaveGame();
        }

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


    private void GetPowersFromStart<ClassType>(Button executeBtn,ParticleSystem vfxParticle,Vector3 vfxParticleLocation) where ClassType : BasePowerUp, new()
    {

        gameObject.AddComponent<ClassType>();
        gameObject.GetComponent<ClassType>().executeButton = executeBtn;
        gameObject.GetComponent<ClassType>().usageCountLeft = gameObject.GetComponent<SaveGameManager>()
                                                                    .savegameAll
                                                                    .GetUsageFromPowerName(gameObject.GetComponent<ClassType>().powerName, gameObject.GetComponent<ClassType>().usageCountLeft);

        gameObject.GetComponent<ClassType>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<ClassType>().powerButtonName + "(" + GetComponent<ClassType>().usageCountLeft + ")";

        //-------- VFX ----------------
         gameObject.GetComponent<ClassType>().powerVFXPrefab = vfxParticle;
         gameObject.GetComponent<ClassType>().powerVFXLocation = vfxParticleLocation;
        //------- END VFX -------------

        
        gameObject.GetComponent<SaveGameManager>().savegameAll.AddValueToUsages(gameObject.GetComponent<ClassType>().powerName, gameObject.GetComponent<ClassType>().usageCountLeft);
    }

    public void ChangeUsageCount<ClassType>() where ClassType : BasePowerUp, new()
    {
        gameObject.GetComponent<ClassType>().executeButton.GetComponentInChildren<Text>().text = gameObject.GetComponent<ClassType>().powerButtonName + "(" + GetComponent<ClassType>().usageCountLeft + ")";

    }




}
