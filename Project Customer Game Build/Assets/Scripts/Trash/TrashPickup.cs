using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    public int scoreWorth = 10;

    public static event Action<float> OnPickupByPlayer;
    

    public static event Action OnPickupByMonster;

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
        Destroy(gameObject);
    }

    /// <summary>
    /// Invokes an event depending on tag.
    /// </summary>
    /// <param name="tag"></param>
    void CheckCollector(string tag)
    {
        if (tag == "Player")
        {
            OnPickupByPlayer?.Invoke(scoreWorth);
        }
        if (tag == "Monster")
        {
           OnPickupByMonster?.Invoke();
        }
    }
}
