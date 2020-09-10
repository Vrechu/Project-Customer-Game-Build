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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
