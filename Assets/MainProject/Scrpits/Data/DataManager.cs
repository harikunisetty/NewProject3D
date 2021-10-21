using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveData saveData;
    public SaveJason saveJson;
    public float Volume
    {
        get { return saveData.volume; }
        set { saveData.volume = value; }
    }

    public bool Vibrations
    {
        get { return saveData.vibrations; }
        set { saveData.vibrations = value; }
    }

    private void Awake()
    {
        saveData = new SaveData();
        saveJson = new SaveJason();
    }

    public void Save()
    {
        saveJson.SaveDataToFile(saveData);
        Debug.Log("DataManager");
    }
    public void Load()
    {
        saveJson.LoadDataToFile(saveData);
       /* Debug.Log("DataManager" + saveJson.LoadDataToFile(saveData));*/
    }
    public void Delete()
    {
        saveJson.DeleteFile();
    }
}
