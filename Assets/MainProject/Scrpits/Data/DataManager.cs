using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public SaveData saveData;

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
    }

    private void OnLevelWasLoaded()
    {
    }
}
