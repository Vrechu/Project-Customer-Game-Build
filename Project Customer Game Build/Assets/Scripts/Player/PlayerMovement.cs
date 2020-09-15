using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalAcceleration = 500;
    public float rotationSpeed = 50;

    public bool SpeedBoostEquipped;
    public float boostAcceleration = 1000;

    float acceleration = 50;
    float backwardsAcceleration;
    public Rigidbody playerRB;

    float forward;
    float sideways;
    float boost;


    float yAngle;

    private void Awake()
    {
        ManagePickups.OnSpeedBoostEquip += EquipSpeedBoost;
        ManagePickups.OnSpeedBoostUnequip += UnequipSpeedBoost;
    }
    private void OnDestroy()
    {
        ManagePickups.OnSpeedBoostEquip -= EquipSpeedBoost;
        ManagePickups.OnSpeedBoostUnequip -= UnequipSpeedBoost;
    }

    void Start()
    {
        acceleration = normalAcceleration;
        backwardsAcceleration = normalAcceleration / 3;
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
        if (forward == 1)
            playerRB.AddForce(transform.forward * forward * acceleration * Time.fixedDeltaTime);
        else if (forward == -1)
            playerRB.AddForce(transform.forward * forward * backwardsAcceleration * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Sets the Y angle of the player using the sideways input float value.
    /// </summary>
    void TurnPlayer()
    {
        yAngle += sideways;
        transform.rotation = Quaternion.Euler(0, yAngle, 0);
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
    /// Unequips the speedboost.
    /// </summary>
    void UnequipSpeedBoost()
    {
        SpeedBoostEquipped = false;
    }

    /// <summary>
    /// Determines the speed of the player.
    /// </summary>
    void ManageSpeed()
    {
        if (SpeedBoostEquipped)
        {
            if (boost == 1)
            {
                acceleration = boostAcceleration;
                ManagePickups.LoseBoost();
            }
            else if (boost == 0)
            {
                acceleration = normalAcceleration;
            }
        }
        else if (!SpeedBoostEquipped)
            acceleration = normalAcceleration;
    }
}
