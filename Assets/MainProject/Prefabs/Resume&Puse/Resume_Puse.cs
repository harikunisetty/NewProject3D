using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Puse : MonoBehaviour
{
    [SerializeField] GameObject ResumeBg;
    [SerializeField] GameObject PuseBg;
    [SerializeField] static bool GameIsPaused;

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
            if (GameIsPaused)
            {
                Resume();
            }
            else
                Pause();
        }
    }
    public void Resume()
    {
        ResumeBg.gameObject.SetActive(false);
        PuseBg.gameObject.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        ResumeBg.gameObject.SetActive(true);
        PuseBg.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
}
