using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePickups : MonoBehaviour
{
    bool isSpeedBoostPickedUp = false;

    public static event Action OnSpeedBoostEquip;

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
       
    }

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
                Debug.Log("speedboost lost");
        }
    }

    void EquipSpeedBoost()
    {
        IsSpeedBoostPickedUp = true;
    }



}
