using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScore : MonoBehaviour
{
    public static event Action OnScoreChange;

    public float score = 0;
    
    
    void Awake()
    {
        OnScoreChange += CheckScore;
        TrashPickup.OnPickupByPlayer += AddScore;
    }

    void OnDestroy()
    {
        OnScoreChange -= CheckScore;
        TrashPickup.OnPickupByPlayer -= AddScore;
    }

    void Start()
    {
        CheckScore();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Adds a point to the score.
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
    }
}
