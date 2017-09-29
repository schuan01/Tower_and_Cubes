using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
	
    public static void SaveCoins(int globalCoins)
    {
		
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        bf.Serialize(file, globalCoins);
        file.Close();
    }

    public static int LoadCoins()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            int coins = (int)bf.Deserialize(file);
            file.Close();

			return coins;

			
        }

		return -1;
    }
}
