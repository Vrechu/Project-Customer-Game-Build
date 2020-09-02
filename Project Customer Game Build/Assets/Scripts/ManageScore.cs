using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScore : MonoBehaviour
{
    public int score = 0;

    void Awake()
    {
        TrashPickup.OnPickupByPlayer += AddScore;
    }

    void OnDestroy()
    {
        TrashPickup.OnPickupByPlayer -= AddScore;
    }

    void Start()
    {
        Debug.Log("Score: " + score);
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Adds a point to the score.
    /// </summary>
    void AddScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
