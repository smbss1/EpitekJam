using System;
using System.IO;
using UnityEngine;


public class Database
{
    public string persistentPath;
    public UnityEngine.Object data;

    public Database(string nameFile, UnityEngine.Object data)
    {
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + nameFile;
        Debug.Log(persistentPath);
        this.data = data;
        LoadData();
    }

    public void SaveData()
    {
        try
        {
            string json = JsonUtility.ToJson(data);

            using StreamWriter writer = new StreamWriter(persistentPath);
            writer.Write(json);
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void LoadData()
    {
        try
        {
            if (File.Exists(persistentPath))
            {
                using StreamReader reader = new StreamReader(persistentPath);

                string json = reader.ReadToEnd();

                JsonUtility.FromJsonOverwrite(json, data);
            }
            else
            {
                Debug.Log("Create file");
                SaveData();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
            SaveData();
        }
    }
}

