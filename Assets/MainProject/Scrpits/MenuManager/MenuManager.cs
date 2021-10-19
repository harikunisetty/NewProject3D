using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MainMenu mainMenuPrefabs;
    [SerializeField] SettingsMenu settingsMenu;
    [SerializeField] Creditsmenu creditsMenu;
    [SerializeField] GameMenu gameMenuPrefab;
    [SerializeField] PauseMenuPrefab pauseGameMenu;
    [SerializeField] Transform menuParentObj;

    [Header("Stack")]

    [SerializeField] Stack<Menu> Stackmenu = new Stack<Menu>();

    [Header("MenuManager")]
    private static MenuManager instance;

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
        if (menuParentObj == null)
        {
            GameObject menuObj = new GameObject("Menu");

            menuParentObj = menuObj.transform;
        }

        DontDestroyOnLoad(menuParentObj);

        Menu[] menusPrefabs = { mainMenuPrefabs, settingsMenu, creditsMenu, gameMenuPrefab, pauseGameMenu};

        foreach(Menu menuPrefab in menusPrefabs)
        {
            if (menuPrefab != null)
            {
                Menu menuInstance = Instantiate(menuPrefab, menuParentObj);

                if (menuPrefab != mainMenuPrefabs)
                {
                    menuPrefab.gameObject.SetActive(false);
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
