using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionUI : MonoBehaviour
{
    public GameObject IntroSprite;
    GameObject introSprite;

    public GameObject ExplainUI;
    GameObject explainUI;
    private void Awake()
    {
        IntroProgression.OnIntroNextWindow += NextIntro;
        IntroProgression.OnIntroClose += HideUIExplenation;
        IntroProgression.OnIntroOpen += ShowIntroductionUI;
    }
    private void OnDestroy()
    {
        IntroProgression.OnIntroNextWindow -= NextIntro;
        IntroProgression.OnIntroClose -= HideUIExplenation;
        IntroProgression.OnIntroOpen -= ShowIntroductionUI;
    }


    void ShowIntroductionUI()
    {
        introSprite = Instantiate(IntroSprite, transform);
    }

    void RemoveIntroductionUI()
    {            
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
        explainUI = Instantiate(ExplainUI, transform);
    }

    void HideUIExplenation()
    {
        if (explainUI != null)
        {
            Destroy(explainUI);
        }
    }
}
