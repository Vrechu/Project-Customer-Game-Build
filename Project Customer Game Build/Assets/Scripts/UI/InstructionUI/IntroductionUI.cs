using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionUI : MonoBehaviour
{
    public GameObject IntroSprite;
    GameObject introSprite;
    private void Awake()
    {
        ManageScenes.OnGameStart += ShowIntroductionUI;
        ManageScenes.OnIntroNextWindow += NextIntro;
    }
    private void OnDestroy()
    {
        ManageScenes.OnGameStart -= ShowIntroductionUI;
        ManageScenes.OnIntroNextWindow -= NextIntro;
    }


    void ShowIntroductionUI()
    {
        MainGameManager.PauseGame();
        introSprite = Instantiate(IntroSprite, transform);
    }

    void RemoveIntroductionUI()
    {
        
        MainGameManager.UnpauseGame();
        if (introSprite != null)
        {
            Destroy(introSprite);
            
        }
    }

    void NextIntro()
    {
        
        RemoveIntroductionUI();
        ShowUIExplenation();
    }

    void ShowUIExplenation()
    {

    }

    void HideUIExplenation()
    {

    }
}
