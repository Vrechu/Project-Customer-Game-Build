using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleCounter : MonoBehaviour
{
    void FixedUpdate()
    {
        UpdateUI();
    }

    /// <summary>
    /// Changes the text display to the current amount of turtles saved.
    /// </summary>
    void UpdateUI()
    {
        GetComponent<Text>().text = "" + ManageScore.turtlesSaved;
    }
}
