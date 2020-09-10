using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ManageInGameMenu : MonoBehaviour
{

    public static event Action OnInGameMenuOpen;
    public static event Action OnInGameMenuClose;

    static bool isMenuOpen;
    bool isMenuKeyPressed = false;

    private void Awake()
    {
        ManageScenes.OnSceneLoad += CloseMenu;
    }

    private void OnDestroy()
    {
        ManageScenes.OnSceneLoad -= CloseMenu;
    }

    private void Update()
    {
        OpenMenuInput();
    }

    /// <summary>
    /// Sets is menu open bool to true.
    /// </summary>
    public static void OpenMenu()
    {
        IsMenuOpen = true;
    }

    /// <summary>
    /// Sets is menu open bool to false.
    /// </summary>
    public static void CloseMenu()
    {
        IsMenuOpen = false;
    }

    /// <summary>
    /// Checks wether the menu is open or closed.
    /// </summary>
    public static bool IsMenuOpen
    {
        get { return isMenuOpen; }
        set
        {
            if (value == isMenuOpen) return;
            isMenuOpen = value;
            if (isMenuOpen)
            {
                OnInGameMenuOpen?.Invoke();
                MainGameManager.PauseGame();
            }
            if (!isMenuOpen)
            {
                OnInGameMenuClose?.Invoke();
                MainGameManager.UnpauseGame();
            }
        }
    }

    /// <summary>
    /// Opens the menu when the escape button is pressed.
    /// </summary>
    void OpenMenuInput()
    {
        if (Input.GetAxis("Cancel") != 0)
        {
            if (!isMenuOpen && !isMenuKeyPressed)
            {
                isMenuKeyPressed = true;
                OpenMenu();
            }            
        }
        if (Input.GetAxis("Cancel") == 0)
        {
            isMenuKeyPressed = false;
        }
    }
}
