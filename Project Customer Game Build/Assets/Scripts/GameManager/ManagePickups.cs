using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePickups : MonoBehaviour
{
    bool isSpeedBoostPickedUp = false;
    static float boostAmount = 0;
    float maxBoostAmount = 180;


    public static event Action OnSpeedBoostEquip;
    public static event Action OnSpeedBoostUnequip;

    private void Awake()
    {
        GainSpeedBoostOnPickup.OnSpeedBoostPickup += EquipSpeedBoost;
    }

    private void OnDestroy()
    {
        GainSpeedBoostOnPickup.OnSpeedBoostPickup -= EquipSpeedBoost;
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

}
