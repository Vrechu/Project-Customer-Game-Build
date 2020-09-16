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
        introSprite = Instantiate(IntroSprite, transform);
    }

    void RemoveIntroductionUI()
    {
        if (introSprite != null)
            Destroy(introSprite);
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
