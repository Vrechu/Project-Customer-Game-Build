using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScore : MonoBehaviour
{
    public static event Action OnScoreChange;
    public static event Action OnTextScoreReached;

    public static float score = 0;
    public static float turtlesSaved = 0;
    public static float dolphinsSaved = 0;
    public float textScore = 30;
    
    void Awake()
    {
        OnScoreChange += CheckScore;
        GainScoreOnPickup.OnScorePickup += AddScore;
        GainShieldOnPickup.OnShieldPickup += AddTurtle;
        GainSpeedBoostOnPickup.OnSpeedBoostPickup += AddDolphin;
        ManageScenes.OnSceneLoad += ResetScore;
    }

    void OnDestroy()
    {
        OnScoreChange -= CheckScore;
        GainScoreOnPickup.OnScorePickup -= AddScore;
        GainShieldOnPickup.OnShieldPickup -= AddTurtle;
        GainSpeedBoostOnPickup.OnSpeedBoostPickup -= AddDolphin;
        ManageScenes.OnSceneLoad -= ResetScore;
    }

    void Start()
    {
        CheckScore();
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
    void CheckScore()
    {
        Debug.Log("Score: " + score);
        if (score >= textScore)
        {
            score = (score - textScore) * -1;
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
    
}
