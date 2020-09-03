using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHealth : MonoBehaviour
{
    public float health = 3;

    private void Awake()
    {
        GetHit.OnPLayerHit += LoseHealth;
    }

    private void OnDestroy()
    {
        GetHit.OnPLayerHit -= LoseHealth;
    }

    void Start()
    {
        Debug.Log("Health: " + health);
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Removes from health depeding on the damage amount.
    /// </summary>
    /// <param name="damage"></param>
    void LoseHealth(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
    }
}
