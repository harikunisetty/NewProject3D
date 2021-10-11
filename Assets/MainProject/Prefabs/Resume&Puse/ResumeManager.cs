using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeManager : MonoBehaviour
{
    public static ResumeManager Instance;
    public bool isPaused;
    void Start()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
