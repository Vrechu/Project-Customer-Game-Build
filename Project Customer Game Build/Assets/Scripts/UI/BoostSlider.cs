using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSlider : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        SetMaxBoost();
    }

    private void FixedUpdate()
    {
        UpdateUI();
    }

    void SetMaxBoost()
    {
        slider.maxValue = ManagePickups.maxBoostAmount;
    }

    void UpdateUI()
    {
        slider.value = ManagePickups.boostAmount;
    }
}
