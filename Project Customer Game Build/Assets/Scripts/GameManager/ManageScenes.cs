using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public static bool IsThisSceneMenu = true;
    public static event Action OnSceneLoad;
    public static event Action OnGameStart;
    public static event Action OnIntroNextWindow;
    

    void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        OnSceneLoad += CheckIfGameStart;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        OnSceneLoad -= CheckIfGameStart;
    }

    void Start()
    {
    }

    void Update()
    {

    }

    /// <summary>
    /// Loads new scene.
    /// </summary>
    /// <param name="sceneName"></param>
    public static void ChangeScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);        
    }
    
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    /// <summary>
    /// Checks if scene has a player in it.
    /// </summary>
    /// <returns></returns>
    public static bool DoesSceneHavePlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            return false;
        }
        else
        {
            return true;
        } 
    }

    public static void NextIntroWindowEvent()
    {
        OnIntroNextWindow?.Invoke();
    }

    void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        OnSceneLoad?.Invoke();
    }

    void CheckIfGameStart()
    {
        if (DoesSceneHavePlayer())
        {
            OnGameStart?.Invoke();
        }
    }
}

