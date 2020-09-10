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
        GetHit.OnPLayerHit += CheckIfShielded;        
    }

    private void OnDestroy()
    {
        OnHealthChange -= CheckHealth;
        OnPlayerDeath -= PlayerDeath;
        GetHit.OnPLayerHit -= CheckIfShielded;        
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
        if (!ManagePickups.IsPLayerShielded)
        {
            LoseHealth(damage);
        }
        else if (ManagePickups.IsPLayerShielded)
        {
            LoseShield();
        }
    }      

    /// <summary>
    /// Sets IsPLayerShielded to false.
    /// </summary>
    void LoseShield()
    {
        ManagePickups.IsPLayerShielded = false;        
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
