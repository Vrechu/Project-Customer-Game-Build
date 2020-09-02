using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform;
    Quaternion lookRotation;
    float xRotation;

    void Start()
    {
        xRotation = cameraTransform.rotation.eulerAngles.x;
    }

    void FixedUpdate()
    {
        
    }

    void SplitQuaternion()
    {
        
    }
        
}
