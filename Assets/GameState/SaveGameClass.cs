using System;
using System.Collections.Generic;

[Serializable]
public class SaveGameClass
{

    int globalCoins = -1;
    public List<KeyValuePair<string, int>> lstPowerUpsUsages = null;


    public int GetGlobalCoins()
    {
        return globalCoins;
    }

    public List<KeyValuePair<string, int>> GetPowerUps()
    {
        return lstPowerUpsUsages;
    }

    public void SetGlobalCoins(int coins)
    {
        globalCoins = coins;
    }

    public void SetListPowerUps(List<KeyValuePair<string, int>> lst)
    {
        lstPowerUpsUsages = lst;
    }


    public SaveGameClass()//Constructor
    {
        globalCoins = -1;
        lstPowerUpsUsages = new List<KeyValuePair<string, int>>();
    }

    public void AddValueToUsages(string powerName, int usages)
    {
        bool powerFound = false;
        for (int i = 0; i < lstPowerUpsUsages.Count; i++)
        {


            if (lstPowerUpsUsages[i].Key == powerName)
            {
                powerFound = true;
                lstPowerUpsUsages.RemoveAt(i);
                if(usages < 0)
                {
                    usages = 0;
                }
                lstPowerUpsUsages.Add(new KeyValuePair<string, int>(powerName, usages));
                break;

            }

        }

        if (!powerFound)
        {

            lstPowerUpsUsages.Add(new KeyValuePair<string, int>(powerName, usages));
        }


    }

    public int GetUsageFromPowerName(string powerName, int currentUsages)
    {
        for (int i = 0; i < lstPowerUpsUsages.Count; i++)
        {
            if (lstPowerUpsUsages[i].Key == powerName)
            {

                return lstPowerUpsUsages[i].Value;
            }

        }

        return currentUsages;
    }

}
