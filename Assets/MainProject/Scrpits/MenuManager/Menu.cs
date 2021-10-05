using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void PlayButton()
    {
        GameManager gameManager = Object.FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.LoadNextLevel();
        }
    }

    public void SettingMenu()
    {
        MenuManager menuManger = Object.FindObjectOfType<MenuManager>();
        Menu settingMenu = transform.parent.Find("Settings Menu(Clone)").GetComponent<Menu>();

        if (menuManger != null && settingMenu != null)
        {
            menuManger.OpenMenu(settingMenu);
        }
    }

    public void CreditMenu()
    {
        MenuManager menuManger = Object.FindObjectOfType<MenuManager>();
        Menu creditsmenu = transform.parent.Find("Credits Menu(Clone)").GetComponent<Menu>();

        if (menuManger != null && creditsmenu != null)
        {
            menuManger.OpenMenu(creditsmenu);
        }
    }
}
