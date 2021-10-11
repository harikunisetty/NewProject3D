using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : Menu<GameMenu>
{
    public void PauseGame ()
    {
        Time.timeScale = 0;
        // Get Pause Menu
       // MenuManager.Instance.OpenMenu(PauseMenu.Instance);
    }

    public void ResumeGame ()
    {
        Time.timeScale = 1;

        if(MenuManager.Instance != null)
        {
            MenuManager.Instance.CloseMenu();
        }
    }
}
