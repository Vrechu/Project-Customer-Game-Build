using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUI : MonoBehaviour
{
    public GameObject BoostSprite;
    GameObject boostSprite;
    private void Awake()
    {
        ManagePickups.OnSpeedBoostEquip += ShowBoostUI;
        ManagePickups.OnSpeedBoostUnequip += RemoveBoostUI;
    }
    private void OnDestroy()
    {
        ManagePickups.OnSpeedBoostEquip -= ShowBoostUI;
        ManagePickups.OnSpeedBoostUnequip -= RemoveBoostUI;
    }
    

    void ShowBoostUI()
    {
        boostSprite = Instantiate(BoostSprite, transform);
    }

    void RemoveBoostUI()
    {
        Destroy(boostSprite);
    }
}
