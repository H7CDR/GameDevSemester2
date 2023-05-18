using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystemScript : MonoBehaviour
{
    static public SaveSystemScript instance;
    string filePath;

    private void Awake()
    {
        //run singleton logic
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        filePath = Application.persistentDataPath + "/save.data";
    }

    public void SaveGame(GameData saveData)
    {
        FileStream dataStream = new FileStream(filePath, FileMode.Create);

        BinaryFormatter converter = new BinaryFormatter();
        converter.Serialize(dataStream, saveData);

        dataStream.Close();
    }

    public GameData LoadGame()
    {
        if(File.Exists(filePath))
        {
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            BinaryFormatter converter = new BinaryFormatter();

            GameData saveData = converter.Deserialize(dataStream) as GameData;

            dataStream.Close();
            return saveData;   
        }
        else
        {
            Debug.LogWarning("Save File Not Found In " + filePath);
            return null;
        }
    }
}
