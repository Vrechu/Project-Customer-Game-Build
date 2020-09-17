using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScore : MonoBehaviour
{
    public static event Action OnScoreChange;
    public static event Action OnTextScoreReached;
    public static event Action OnAllTrashCollected;

    public static float score = 0;
    public static float totalScore;
    public static float turtlesSaved = 0;
    public static float dolphinsSaved = 0;
    float textScore = 0;
    public float TextWindowScoreInterval = 5;
    
    void Awake()
    {
        OnScoreChange += CheckTextScore;
        GainScoreOnPickup.OnScorePickup += AddScore;
        GainScoreOnPickup.OnScorePickup += CheckWinScore;
        GainShieldOnPickup.OnShieldPickup += AddTurtle;
        GainSpeedBoostOnPickup.OnSpeedBoostPickup += AddDolphin;
        ManageScenes.OnSceneLoad += ResetScore;
        ManageScenes.OnGameStart += ResetScore;
    }

    void OnDestroy()
    {
        OnScoreChange -= CheckTextScore;
        GainScoreOnPickup.OnScorePickup -= AddScore;
        GainScoreOnPickup.OnScorePickup -= CheckWinScore;
        GainShieldOnPickup.OnShieldPickup -= AddTurtle;
        GainSpeedBoostOnPickup.OnSpeedBoostPickup -= AddDolphin;
        ManageScenes.OnSceneLoad -= ResetScore;
    }

    void Start()
    {
        totalScore = GameObject.FindGameObjectsWithTag("ScoreObject").Length;
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Adds points to the current score.
    /// </summary>
    void AddScore(float scoreWorth)
    {
        score += scoreWorth;
        OnScoreChange?.Invoke();
    }

    /// <summary>
    /// Prints the current score.
    /// </summary>
    void CheckTextScore()
    {
        textScore++;
        if (textScore == TextWindowScoreInterval)
        {
            textScore = 0;
            OnTextScoreReached?.Invoke();
        }        
    }

    void ResetScore()
    {
        score = 0;
        turtlesSaved = 0;
        dolphinsSaved = 0;
    }

    void AddTurtle()
    {
        turtlesSaved++;
    }

    void AddDolphin()
    {
        dolphinsSaved++;
    }  
    
    void CheckWinScore(float score)
    {
        if (score >= totalScore)
        {
            OnAllTrashCollected?.Invoke();
        }
    }

    void CountTotalScore()
    {

    }
}
