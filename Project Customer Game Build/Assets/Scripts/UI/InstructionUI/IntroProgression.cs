using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroProgression : MonoBehaviour
{
    public static event Action OnIntroNextWindow;
    public static event Action OnIntroClose;
    public static event Action OnIntroOpen;

    private void Awake()
    {
        ManageScenes.OnGameStart += OpenIntroWindowEvent;
    }

    private void OnDestroy()
    {
        ManageScenes.OnGameStart -= OpenIntroWindowEvent;
    }

    public static void NextIntroWindowEvent()
    {
        OnIntroNextWindow?.Invoke();
    }

    public static void CloseIntroWindowEvent()
    {
        OnIntroClose?.Invoke();
        MainGameManager.UnpauseGame();
    }

    public static void OpenIntroWindowEvent()
    {
        OnIntroOpen?.Invoke();
        MainGameManager.PauseGame();
    }
        
}
