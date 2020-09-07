using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainSpeedBoostOnPickup : MonoBehaviour
{
    public static event Action OnSpeedBoostPickup;

    void Start()
    {
        
    }

    void Update()
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
            OnSpeedBoostPickup?.Invoke();              
        }
    }
}
