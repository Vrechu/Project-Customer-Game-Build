using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class TextLoader : MonoBehaviour
{
    public string fileName1;
    public float triggerScore1 = 5;
    public string fileName2;
    public float triggerScore2 = 10;
    public string fileName3;
    public float triggerScore3 = 15;
    public string fileName4;
    public float triggerScore4 = 20;
    public string fileName5;
    public float triggerScore5 = 25;

    TextAsset loadedText;

    private void Awake()
    {
        SwitchText();
        UpdateUI();
    }

    void Start()
    {
        
    }

    void SwitchText()
    {
        if (ManageScore.score <= triggerScore1)
            loadedText = (TextAsset)Resources.Load(fileName1);
        else if (ManageScore.score <= triggerScore2)
            loadedText = (TextAsset)Resources.Load(fileName2);
        else if (ManageScore.score <= triggerScore3)
            loadedText = (TextAsset)Resources.Load(fileName3);
        else if (ManageScore.score <= triggerScore4)
            loadedText = (TextAsset)Resources.Load(fileName4);
        else if (ManageScore.score <= triggerScore5)
            loadedText = (TextAsset)Resources.Load(fileName5);        
    }
    void UpdateUI()
    {
        GetComponent<Text>().text = loadedText.text;
    }
}
