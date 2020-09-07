using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageHealth : MonoBehaviour
{
    public float health = 3;

    public static event Action OnHealthChange;
    public static event Action OnPlayerDeath;

    public bool IsPlayerShielded = false;

    private void Awake()
    {
        OnHealthChange += CheckHealth;
        OnPlayerDeath += PlayerDeath;
        GetHit.OnPLayerHit += CheckIfShielded;
        GainShieldOnPickup.OnShieldPickup += AddShield;
    }

    private void OnDestroy()
    {
        OnHealthChange -= CheckHealth;
        OnPlayerDeath -= PlayerDeath;
        GetHit.OnPLayerHit -= CheckIfShielded;
        GainShieldOnPickup.OnShieldPickup -= AddShield;
    }

    void Start()
    {
        CheckHealth();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Checks Subtracks the damage from playerhealth if not shielded. Removes the shield if shielded.
    /// </summary>
    /// <param name="damage"></param>
    void CheckIfShielded(float damage)
    {
        if (!IsPlayerShielded)
        {
            LoseHealth(damage);
        }
        else if (IsPlayerShielded)
        {
            LoseShield();
        }
    }

    /// <summary>
    /// Sets IsPLayerShielded to true.
    /// </summary>
    void AddShield()
    {
        IsPlayerShielded = true;
        Debug.Log("SHIELDED");
    }

    /// <summary>
    /// Sets IsPLayerShielded to false.
    /// </summary>
    void LoseShield()
    {
        IsPlayerShielded = false;
        Debug.Log("SHIELD LOST");
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
        ManageScenes.ChangeScene("Menu");
    }
}
