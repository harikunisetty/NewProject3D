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
        SettingsMenu settings = transform.parent.Find("Settings_Menu(Clone)").GetComponent<SettingsMenu>();
        if (MenuManager.Instance != null && SettingsMenu.Instance != null)
        {
            Debug.Log("Setting Button Pressed");
            MenuManager.Instance.OpenMenu(SettingsMenu.Instance);
        }
    }

    public void CreditButton()
    {
        CreditsMenu credits = transform.parent.Find("CREDIT_MENU(Clone)").GetComponent<CreditsMenu>();
        if (MenuManager.Instance != null && credits != null)
        {
            MenuManager.Instance.OpenMenu(credits);
        }
    }

    public override void BackButton()
    {
        Application.Quit();
    }
}
