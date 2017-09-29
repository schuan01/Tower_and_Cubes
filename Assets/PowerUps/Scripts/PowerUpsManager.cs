using UnityEngine;
using UnityEngine.UI;
public class PowerUpsManager : MonoBehaviour
{

    public Button explodeButton;

    
    
    void Start()
    {
        

        gameObject.AddComponent<ExplodePowerUp>();
        gameObject.GetComponent<ExplodePowerUp>().executeButton = explodeButton;
    }

    
    void Update()
    {

    }

    public void ExplodeEnemies()//Explota todo los enemigos de la vuelta
    {
        
        if (GetComponent<ExplodePowerUp>().coinCost <= GetComponent<CoinsManager>().globalCoins)
        {
            GetComponent<CoinsManager>().DecreseCoins(GetComponent<ExplodePowerUp>().coinCost);
            gameObject.GetComponent<ExplodePowerUp>().Execute();
        }
        
    }


}
