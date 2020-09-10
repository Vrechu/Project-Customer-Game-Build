using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    public GameObject ShieldSprite;
    GameObject shieldSprite;
    private void Awake()
    {
        ManagePickups.OnShieldEquip += ShowShieldUI;
        ManagePickups.OnShieldUnequip += RemoveShieldUI;
    }
    private void OnDestroy()
    {
        ManagePickups.OnShieldEquip -= ShowShieldUI;
        ManagePickups.OnShieldUnequip -= RemoveShieldUI;
    }


    void ShowShieldUI()
    {
        shieldSprite = Instantiate(ShieldSprite, transform);
    }

    void RemoveShieldUI()
    {
        if (shieldSprite != null)
        Destroy(shieldSprite);
    }
}
