using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveGameManager : MonoBehaviour
{

    public SaveGameClass savegameAll = null;
    void Start()
    {

        

    }

    void Awake()
    {
        LoadGame();//Carga el juego y alimenta la variable publica
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/tower.gd");
        bf.Serialize(file, savegameAll);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/tower.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/tower.gd", FileMode.Open);
            savegameAll = (SaveGameClass)bf.Deserialize(file);
            file.Close();

        }
        else
        {
            savegameAll = new SaveGameClass();
        }


    }

    
}
