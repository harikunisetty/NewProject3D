using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] Menu mainMenuPrefab;
    [SerializeField] Menu settingsMenuPrefab;
    [SerializeField] Menu creditsMenuPrefab;
    [SerializeField] Transform menuParentObject;

    [Header("Stack Menus")]
    [SerializeField] Stack<Menu> menuStack = new Stack<Menu>();

    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance != this)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    void Start()
    {
        CreateMenus();
    }

    void CreateMenus()
    {
        if (menuParentObject == null)
        {
            GameObject menusObj = new GameObject("Menus"); 
            menuParentObject = menusObj.transform; 
        }

        Menu[] menus = { mainMenuPrefab, settingsMenuPrefab, creditsMenuPrefab };

        foreach (Menu menuPrefab in menus)
        {
            if (menuPrefab != null)
            {
                Menu menuInstance = Instantiate(menuPrefab, menuParentObject);

                if (menuPrefab != mainMenuPrefab)
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
        if (menuInstance == null)
        {
            return;
        }

        if (menuStack.Count > 0)
        {
            foreach (Menu menuitem in menuStack)
            {
                menuitem.gameObject.SetActive(false);
            }
        }

        menuInstance.gameObject.SetActive(true); 
        menuStack.Push(menuInstance); 
    }

    public void CloseMenu()
    {
        if (menuStack.Count == 0)
        {
            return;
        }

        Menu topMenu = menuStack.Pop();
        topMenu.gameObject.SetActive(false);

        if (menuStack.Count > 0)
        {
            Menu nextMenu = menuStack.Peek();
            nextMenu.gameObject.SetActive(true);
        }
    }
}

