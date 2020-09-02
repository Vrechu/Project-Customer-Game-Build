using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody playerRB;
    public float movementSpeed = 5;

    float forward;
    float sideways;

    void Start()
    {       
    }

    void FixedUpdate()
    {
        SetKeys();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 zVelocity = transform.forward * forward;
        Vector3 xVelocity = transform.right * sideways;
        Vector3 horizontalVelocity = (zVelocity + xVelocity).normalized * movementSpeed;
        playerRB.velocity = new Vector3(horizontalVelocity.x, playerRB.velocity.y, horizontalVelocity.z);
    }

    void SetKeys()
    {
        forward = Input.GetAxis("Vertical");
        sideways = Input.GetAxis("Horizontal");        
    }
}
