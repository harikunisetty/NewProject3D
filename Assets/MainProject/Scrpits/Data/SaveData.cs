using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string playerName;
    private readonly string playerDefaultName = "Player";

    public float volume;
    public bool vibrations;

    public SaveData()
    {
        playerName = playerDefaultName;
        volume = 1f;
        vibrations = false;
    }
}
