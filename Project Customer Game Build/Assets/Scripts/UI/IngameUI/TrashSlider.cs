﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashSlider : MonoBehaviour
{
    
    public Slider slider;
    float reversedScore;

    private void Update()
    {
        SetMaxScore();
        ReverseScore();
        UpdateUI();
    }

    void SetMaxScore()
    {
        slider.maxValue = ManageScore.totalScore;
        Debug.Log("max slider value: " + ManageScore.totalScore);
    }

    void UpdateUI()
    {
        slider.value = reversedScore;
        Debug.Log("slider value: " + slider.value);
        Debug.Log("score: " + reversedScore);
    }

    void ReverseScore()
    {
        reversedScore = ManageScore.totalScore  - ManageScore.score;
    }    
}
