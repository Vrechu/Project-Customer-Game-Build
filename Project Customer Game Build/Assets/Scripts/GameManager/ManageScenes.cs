using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    public static bool IsThisSceneMenu = true;

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
    /// Loads new scene.
    /// </summary>
    /// <param name="sceneName"></param>
    public static void ChangeScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);        
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
}

