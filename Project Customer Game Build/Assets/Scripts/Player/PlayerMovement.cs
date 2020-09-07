using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float movementSpeed = 50;
    public float rotationSpeed = 10;

    public bool SpeedBoostEquipped;
    public float boostSpeed = 10000;

    float speed = 50;
    public Rigidbody playerRB;

    float forward;
    float sideways;
    float boost;


    float yAngle;

    private void Awake()
    {
        ManagePickups.OnSpeedBoostEquip += EquipSpeedBoost;
    }
    private void OnDestroy()
    {
        ManagePickups.OnSpeedBoostEquip -= EquipSpeedBoost;
    }

    void Start()
    {
        speed = movementSpeed;
        yAngle = transform.rotation.eulerAngles.y;
    }
    
    void FixedUpdate()
    {
        SetKeys();
        ManageSpeed();
        MovePlayer();
        TurnPlayer();
    }

    /// <summary>
    /// Sets the forward velocity of the player using the forward input float value.
    /// </summary>
    void MovePlayer()
    {
        playerRB.velocity = transform.forward * forward * speed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Sets the Y angle of the player using the sideways input float value.
    /// </summary>
    void TurnPlayer()
    {
        yAngle += sideways;
        transform.rotation = Quaternion.Euler(0, yAngle , 0);
    }

    /// <summary>
    /// Assings input values to floats.
    /// </summary>
    void SetKeys()
    {
        forward = Input.GetAxis("Vertical");
        sideways = Input.GetAxis("Horizontal");

        boost = Input.GetAxis("Fire3");
    }

    /// <summary>
    /// Equips the speedboost.
    /// </summary>
    void EquipSpeedBoost()
    {
        SpeedBoostEquipped = true;
    }

    /// <summary>
    /// Determines the speed of the player.
    /// </summary>
    void ManageSpeed()
    {
        if (SpeedBoostEquipped) {
            if (boost == 1)
                speed = boostSpeed;
            else if (boost == 0)
            {
                speed = movementSpeed;
            }
    } }
    
}
