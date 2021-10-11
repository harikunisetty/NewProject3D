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
    }

    public void SettingButton()
    {
        Menu settingMenu = transform.parent.Find("Settings Menu(Clone)").GetComponent<SettingsMenu>();

        if (MenuManager.Instance != null && settingMenu != null)
        {
            Debug.Log("Setting Button Pressed");
            MenuManager.Instance.OpenMenu(settingMenu);
        }
    }

    public void CreditButton()
    {
        if (MenuManager.Instance != null && CreditsMenu.Instance != null)
        {
            MenuManager.Instance.OpenMenu(CreditsMenu.Instance);
        }
    }

    public override void BackButton()
    {
        Application.Quit();
    }
}
