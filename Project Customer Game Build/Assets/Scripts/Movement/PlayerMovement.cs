using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float movementSpeed = 50;
    public float rotationSpeed = 10;
    public Rigidbody playerRB;

    float forward;
    float sideways;

    float yAngle;

    void Start()
    {
        yAngle = transform.rotation.eulerAngles.y;
    }
    
    void FixedUpdate()
    {
        SetKeys();
        MovePlayer();
        TurnPlayer();
    }

    /// <summary>
    /// Sets the forward velocity of the player using the forward input float value.
    /// </summary>
    void MovePlayer()
    {
        playerRB.velocity = transform.forward * forward * movementSpeed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Sets the Y angle of the player using the sideways input float value.
    /// </summary>
    void TurnPlayer()
    {
        yAngle = yAngle + sideways;
        transform.rotation = Quaternion.Euler(0, yAngle , 0);
    }

    /// <summary>
    /// Assings input values to floats.
    /// </summary>
    void SetKeys()
    {
        forward = Input.GetAxis("Vertical");
        sideways = Input.GetAxis("Horizontal");
    }
}
