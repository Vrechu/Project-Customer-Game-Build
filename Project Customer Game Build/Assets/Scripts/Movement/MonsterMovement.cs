using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    
    public float movementSpeed = 50;
    public float turnSpeed = 0.1f;
    public Rigidbody monsterRB;

    Transform player;
    Quaternion lookRotation;
    Vector3 relativePlayerDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        MoveMonster();
        TrackPlayerDirection();
        TurnToPlayer();
    }

    void MoveMonster()
    {
        monsterRB.velocity = transform.forward * movementSpeed * Time.fixedDeltaTime;
    }

    void TrackPlayerDirection()
    {
        relativePlayerDirection = player.position - transform.position;
        Quaternion playerFacingRotation = Quaternion.LookRotation(relativePlayerDirection);
        lookRotation = Quaternion.Euler(0, playerFacingRotation.eulerAngles.y, 0);
    }

    void TurnToPlayer()
    {
        lookRotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed);
        transform.rotation = lookRotation;
    }
}
