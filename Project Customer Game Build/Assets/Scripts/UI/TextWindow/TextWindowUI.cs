using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindowUI : MonoBehaviour
{
    public static event Action OnTextWindowOpen;
    public static event Action OnTextWindowClose;

    public GameObject TextWindow;
    static GameObject textWindow;
    

    static bool isTextWindowOpen;

    private void Awake()
    {
        ManageScore.OnTextScoreReached += OpenTextWindow;
    }

    private void OnDestroy()
    {
        ManageScore.OnTextScoreReached -= OpenTextWindow;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OpenTextWindow()
    {
        textWindow = GameObject.Instantiate(TextWindow, transform);
        OnTextWindowOpen?.Invoke();
        MainGameManager.PauseGame();
    }

    public static void CloseTextWindow()
    {
        if (textWindow != null)
        {
            Destroy(textWindow);
        }
            OnTextWindowClose?.Invoke();
        MainGameManager.UnpauseGame();
    }
}
