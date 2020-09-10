using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    void Awake()
    {

    }

    void OnDestroy()
    {

    }

    void Start()
    {

    }

    void Update()
    {

    }

    /// <summary>
    /// Calls the loadScene method from the scene manager.
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName)
    {
        ManageScenes.ChangeScene(sceneName);
    }

    /// <summary>
    /// Closes the game.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Opens the in-game menu.
    /// </summary>
    public void OpenMenu()
    {
        ManageInGameMenu.OpenMenu();
    }

    /// <summary>
    /// Closes the in-game menu.
    /// </summary>
    public void CloseMenu()
    {
        ManageInGameMenu.CloseMenu();
    }

    public void RestartScene()
    {
        ManageScenes.ReloadScene();      
    }

    public void CloseTextWindow()
    {
        TextWindowUI.CloseTextWindow();
    }
}
