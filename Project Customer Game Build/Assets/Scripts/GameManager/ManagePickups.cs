using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePickups : MonoBehaviour
{
    bool isSpeedBoostPickedUp = false;
    public static float boostAmount = 0;
    public static float maxBoostAmount = 180;

    public static event Action OnSpeedBoostEquip;
    public static event Action OnSpeedBoostUnequip;

    static bool isPLayerShielded = false;
    public static event Action OnShieldEquip;
    public static event Action OnShieldUnequip;


    private void Awake()
    {
        GainSpeedBoostOnPickup.OnSpeedBoostPickup += EquipSpeedBoost;
        GainShieldOnPickup.OnShieldPickup += EquipShield;
        ManageScenes.OnSceneLoad += ResetPickups;
    }

    private void OnDestroy()
    {
        GainSpeedBoostOnPickup.OnSpeedBoostPickup -= EquipSpeedBoost;
        GainShieldOnPickup.OnShieldPickup -= EquipShield;
        ManageScenes.OnSceneLoad -= ResetPickups;
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckSpeedBoostAmount();
    }

    /// <summary>
    /// Bool that sends out an event when switched.
    /// </summary>
    public bool IsSpeedBoostPickedUp
    {
        get
        {
            return isSpeedBoostPickedUp;
        }
        set
        {
            if (value == isSpeedBoostPickedUp) return;
            isSpeedBoostPickedUp = value;
            if (isSpeedBoostPickedUp)
                OnSpeedBoostEquip?.Invoke();
            if (!isSpeedBoostPickedUp)
                OnSpeedBoostUnequip?.Invoke();
        }
    }

    /// <summary>
    /// Switches IsSpeedBoostPickedUp to true and adds boost to use.
    /// </summary>
    void EquipSpeedBoost()
    {
        IsSpeedBoostPickedUp = true;
        boostAmount = maxBoostAmount;
    }

    /// <summary>
    /// Switches IsSpeedBoostPickedUp to false.
    /// </summary>
    void UnequipSpeedBoost()
    {
        IsSpeedBoostPickedUp = false;
    }

    /// <summary>
    /// Reduces boost amount by 1 whenever called.
    /// </summary>
    public static void LoseBoost()
    {
        boostAmount--;
    }

    /// <summary>
    /// switches isSpeedBoostPickedUp when boost amount reaches 0.
    /// </summary>
    void CheckSpeedBoostAmount()
    {
        if (isSpeedBoostPickedUp
            && boostAmount < 0)
        {
            UnequipSpeedBoost();
        }
    }

    /// <summary>
    /// Equips player shield.
    /// </summary>
    void EquipShield()
    {
        IsPLayerShielded = true;
    }

    /// <summary>
    /// Sends out an event when shields gets picked up or lost. 
    /// </summary>
    public static bool IsPLayerShielded
    {
        get { return isPLayerShielded; }
        set
        {
            if (value == isPLayerShielded) return;
            isPLayerShielded = value;
            if (isPLayerShielded)
                OnShieldEquip?.Invoke();
            if (!isPLayerShielded)
                OnShieldUnequip?.Invoke();
        }
    }

    void ResetPickups()
    {
        IsSpeedBoostPickedUp = false;
        IsPLayerShielded = false;
    }
}
