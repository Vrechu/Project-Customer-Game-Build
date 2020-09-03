using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
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

    public static void LoadScene(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }        
}
