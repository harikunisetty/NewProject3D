using UnityEngine;
using System.IO;
public class SaveJason
{
    private static readonly string fileName = "SaveGameData01.sav";

    // File + File Path
    public static string GetFileName()
    {
        return Application.persistentDataPath + "/" + fileName;
    }

    // Save File
    public void SaveDataToFile(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        string file = GetFileName();

        FileStream fileStream = new FileStream(file, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    // Get File
    public bool LoadDataToFile(SaveData data)
    {
        string loadFile = GetFileName();

        if(File.Exists(loadFile))
        {
            using (StreamReader reader = new StreamReader(loadFile))
            {
                string json = reader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(json, data);
            }
            return true;
        }
        return false;
    }

    // Delete File
    public void DeleteFile()
    {
        File.Delete(GetFileName());
    }
}
