using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu :Menu<MainMenu>
{
    public void PlayButton()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadNextLevel();
        }
        GameMenu.Open();
    }

    public void SettingButton()
    {
        SettingsMenu.Open();
        Debug.Log("touch settings menu");
    }

    public void CreditButton()
    {
        Creditsmenu.Open();
    }

    public override void BackButton()
    {
        Application.Quit();
    }
}
