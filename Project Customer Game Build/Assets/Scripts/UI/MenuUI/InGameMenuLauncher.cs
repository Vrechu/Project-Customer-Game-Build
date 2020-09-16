using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuLauncher : MonoBehaviour
{
    public GameObject Menu;
    GameObject menu;

    private void Awake()
    {
        ManageInGameMenu.OnInGameMenuOpen += OpenMenu;
        ManageInGameMenu.OnInGameMenuClose += CloseMenu;
    }
    private void OnDestroy()
    {
        ManageInGameMenu.OnInGameMenuOpen -= OpenMenu;
        ManageInGameMenu.OnInGameMenuClose -= CloseMenu;
    }
 
    /// <summary>
    /// Instantiates the in game menu.
    /// </summary>
    void OpenMenu()
    {
        menu = Instantiate(Menu, transform);
    }

    /// <summary>
    /// Destroys the in game menu.
    /// </summary>
    void CloseMenu()
    {
        if (menu != null)
            Destroy(menu);
    }
}
