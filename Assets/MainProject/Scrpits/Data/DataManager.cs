using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveData saveData;
    public SaveJason jsonFile;
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
        jsonFile = new SaveJason();
    }

    public void Save()
    {
        jsonFile.SaveDataToFile(saveData);
    }

    public void Load()
    {
        jsonFile.LoadDataToFile(saveData);
    }

    public void Delete()
    {
        jsonFile.DeleteFile();
    }
}
