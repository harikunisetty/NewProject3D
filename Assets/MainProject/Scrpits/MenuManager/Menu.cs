using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void PlayButton()
    {
        //GameManager gameManager = Object.FindObjectOfType<GameManager>();

        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }

    public void SettingMenu()
    {
       //MenuManager menuManger = Object.FindObjectOfType<MenuManager>();
        Menu settingMenu = transform.parent.Find("Settings Menu(Clone)").GetComponent<Menu>();

        if (MenuManager.Instance != null && settingMenu != null)
        {
            MenuManager.Instance.OpenMenu(settingMenu);
        }
    }

    public void CreditMenu()
    {
        //MenuManager menuManger = Object.FindObjectOfType<MenuManager>();
        Menu creditsmenu = transform.parent.Find("Credits Menu(Clone)").GetComponent<Menu>();

        if (MenuManager.Instance != null && creditsmenu != null)
        {
            MenuManager.Instance.OpenMenu(creditsmenu);
        }
    }

    public void Back()
    {
        //MenuManager menuManger = Object.FindObjectOfType<MenuManager>();
        if (MenuManager.Instance != null)
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}
