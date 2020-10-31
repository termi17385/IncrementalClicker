using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    [System.Serializable]
    public class SaveSystemData
    {
        public PlayerData playerData;
        public EnchancementData enchancementData;

        public SaveSystemData()
        {
             playerData = new PlayerData();
             enchancementData = new EnchancementData();
        }
    }

    static public SaveSystemData loadedData;

    /// <summary>
    /// Method that saves the data in binary formatt and creates a file
    /// </summary>
    public static void SaveGame()
    {
        // formatts the data
        BinaryFormatter formatter = new BinaryFormatter();
        // sets a file path for storing the save
        string path = Application.persistentDataPath + "/GameSave.NotASaveFile";
        // opens a file stream used to save the file to the choosen path
        FileStream stream = new FileStream(path, FileMode.Create);

        // Defines what data is to be saved
        SaveSystemData data = new SaveSystemData();

        // serializes the stream and the data
        formatter.Serialize(stream, data);
        // closes the stream
        stream.Close();
    }   
    
    /// <summary>
    /// loads the game data from the choosen file path
    /// </summary>
    public static void Load()
    {
        // sets the path to use
        string path = Application.persistentDataPath + "/GameSave.NotASaveFile";
        // checks for if the file exists
        if (File.Exists(path))
        {
            // formatts the file
            BinaryFormatter formatter = new BinaryFormatter();
            // opens the stream and file
            FileStream stream = new FileStream(path, FileMode.Open);

            // deserializes the data as systemData then closes the stream
            SaveSystemData data = formatter.Deserialize(stream) as SaveSystemData;
            stream.Close();

            // sets data as = to data
            loadedData =  data;
        }
        else
        {
            // else sends an error log
            Debug.LogError("No Save File in" + path);
        }
    }
}
