using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    public float speed = 0f;

    public bool ForwardY = false;

    public bool ReverseY = false;

    void Update()
    {
            if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }

        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }

    }
}