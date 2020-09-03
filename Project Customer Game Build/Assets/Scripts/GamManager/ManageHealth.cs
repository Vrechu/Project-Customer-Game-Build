using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHealth : MonoBehaviour
{
    public float health = 3;

    public static event Action OnHealthChange;
    public static event Action OnPlayerDeath;

    private void Awake()
    {
        OnHealthChange += CheckHealth;
        OnPlayerDeath += PlayerDeath;
        GetHit.OnPLayerHit += LoseHealth;
    }

    private void OnDestroy()
    {
        OnHealthChange -= CheckHealth;
        OnPlayerDeath += PlayerDeath;
        GetHit.OnPLayerHit -= LoseHealth;
    }

    void Start()
    {
        CheckHealth();
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
        OnHealthChange?.Invoke();
    }

    /// <summary>
    /// Checks the health of the player and sends out an event when it reaches 0.
    /// </summary>
    void CheckHealth()
    {
        if (health <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
        else Debug.Log("Health: " + health);
    }

    /// <summary>
    /// Loads the start menu screen on death.
    /// </summary>
    void PlayerDeath()
    {
        Debug.Log("Game Over");
        ManageScenes.LoadScene("Menu");
    }
}
