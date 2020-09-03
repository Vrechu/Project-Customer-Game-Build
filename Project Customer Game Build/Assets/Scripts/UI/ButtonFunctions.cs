using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void LoadScene(string sceneName)
    {
        ManageScenes.LoadScene(sceneName);
    }
}
