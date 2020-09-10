using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBoostAmount : MonoBehaviour
{

    void FixedUpdate()
    {
        UpdateUI();
    }

    /// <summary>
    /// Changes the text display to the current amount of boost left.
    /// </summary>
    void UpdateUI()
    {
        GetComponent<Text>().text = "" + ManagePickups.boostAmount;
    }
}
