using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MainMenu mainMenuPrefabs;
    [SerializeField] SettingsMenu settingsMenu;
    [SerializeField] CreditsMenu creditsMenu;
    [SerializeField] GameMenu gameMenu;
    [SerializeField] Transform menuParentObj;

    [Header("Stack")]

    [SerializeField] Stack<Menu> Stackmenu = new Stack<Menu>();

    [Header("MenuManager")]
    private static MenuManager instance;
    //private Menu menuInstance;

    public static MenuManager Instance { get => instance; }

    public void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            instance = this;
            CreateMenu();
        }

        DontDestroyOnLoad(this);
    }
    public void OnDestroy()
    {
        instance = null;
    }

   void CreateMenu()
   {
        if (menuParentObj != null)
        {
            return;
        }

        GameObject menuObj = new GameObject("Menu");
        menuParentObj = menuObj.transform;

        Menu[] menus = { mainMenuPrefabs, settingsMenu, creditsMenu, gameMenu };
        foreach(Menu menuPrefabs in menus)
        {
            if (menuPrefabs != null)
            {
                Menu menuInstance = Instantiate(menuPrefabs, menuParentObj);

                if (menuPrefabs != mainMenuPrefabs)
                {
                    menuPrefabs.gameObject.SetActive(false);
                }
                else
                {
                    OpenMenu(menuInstance);
                }
            }
            
        }
   }
    public void OpenMenu(Menu menuInstance)
    {
        if(menuInstance == null)
        {
            return;
        }

        if(Stackmenu.Count > 0)
        {
            foreach (Menu menuitem in Stackmenu)
            {
                menuitem.gameObject.SetActive(false);
            }
        }

        menuInstance.gameObject.SetActive(true); 
        Stackmenu.Push(menuInstance); 
    }

    public void CloseMenu()
    {
        if (Stackmenu.Count == 0)
        {
            return;
        }

        Menu topMenu = Stackmenu.Pop();
        topMenu.gameObject.SetActive(false);

        if (Stackmenu.Count > 0)
        {
            Menu nextMenu = Stackmenu.Peek();
            nextMenu.gameObject.SetActive(true);
        }
    }
}
