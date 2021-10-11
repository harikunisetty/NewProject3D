using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Puse : MonoBehaviour
{
    [SerializeField] GameObject ResumeBg;

    void Start()
    {
        ResumeBg.gameObject.SetActive(false);
    }

    void Update()
    {
        InventoryControl();
    }
    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ResumeManager.Instance.isPaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    private void Resume()
    {
        ResumeBg.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    private void Pause()
    {
        ResumeBg.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
