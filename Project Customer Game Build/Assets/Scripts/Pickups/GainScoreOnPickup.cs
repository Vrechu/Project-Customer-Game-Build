using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainScoreOnPickup : MonoBehaviour
{
    public int scoreWorth = 10;

    public static event Action<float> OnScorePickup;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }


    /// <summary>
    /// Gets called when on a collision. 
    /// Checks who the collector is and then destroys the gameObject.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        CheckCollector(other.tag);        
    }

    /// <summary>
    /// Invokes an event depending on tag.
    /// </summary>
    /// <param name="tag"></param>
    void CheckCollector(string tag)
    {
        if (tag == "Player")
        {
            OnScorePickup?.Invoke(scoreWorth);
        }
    }
}
