using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DolphinCounter : MonoBehaviour
{
    void FixedUpdate()
    {
        UpdateUI();
    }

    /// <summary>
    /// Changes the text display to the current amount of dolphins saved.
    /// </summary>
    void UpdateUI()
    {
        GetComponent<Text>().text = "" + ManageScore.dolphinsSaved;
    }
}
