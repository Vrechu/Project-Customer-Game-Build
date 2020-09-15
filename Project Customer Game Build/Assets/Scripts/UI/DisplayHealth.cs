using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    void FixedUpdate()
    {
        UpdateUI();
    }

    /// <summary>
    /// Changes the text display to the current amount of health left.
    /// </summary>
    void UpdateUI()
    {
        GetComponent<Text>().text = "" + ManageScore.turtlesSaved;
    }
}
