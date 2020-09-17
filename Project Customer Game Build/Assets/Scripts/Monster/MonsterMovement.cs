using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    
    public float movementSpeed = 150;
    public float turnSpeed = 0.1f;
    public float maxSpeed = 300;
    public float maxSize = 2;
    float acceleration;
    float growth;
    public Rigidbody monsterRB;

    Transform player;
    Quaternion lookRotation;
    Vector3 relativePlayerDirection;

    private void Awake()
    {
        ManageScore.OnScoreChange += Accelerate;
        ManageScore.OnScoreChange += Grow;
    }

    private void OnDestroy()
    {
        ManageScore.OnScoreChange -= Accelerate;
        ManageScore.OnScoreChange -= Grow;
    }

    void Start()
    {
        CalculateAcceleration();
        if (ManageScenes.DoesSceneHavePlayer() != false)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (ManageScenes.DoesSceneHavePlayer() != false)
        {
            CalculateAcceleration();
            CalculateGrowth();
            MoveMonster();
            TrackPlayerDirection();
            TurnToPlayer();
        }
    }

    /// <summary>
    /// Sets the velocity of the monster to the direction he is facing. 
    /// </summary>
    void MoveMonster()
    {
        monsterRB.velocity = transform.forward * movementSpeed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Sets the lookRotation to face the player.
    /// </summary>
    void TrackPlayerDirection()
    {
        relativePlayerDirection = player.position - transform.position;
        Quaternion playerFacingRotation = Quaternion.LookRotation(relativePlayerDirection);
        lookRotation = Quaternion.Euler(0, playerFacingRotation.eulerAngles.y, 0);
    }

    /// <summary>
    /// Gradually rotates the transform rotation of the monster in the direction of the lookRotation.
    /// </summary>
    void TurnToPlayer()
    {
        lookRotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed);
        transform.rotation = lookRotation;
    }

    void Accelerate()
    {
        movementSpeed += acceleration;
    }

    void CalculateAcceleration()
    {
        acceleration = (maxSpeed - movementSpeed) / ManageScore.totalScore;
    }

    void Grow()
    {
        transform.localScale.Set(transform.localScale.x * growth, transform.localScale.y  * growth, transform.localScale.z * growth);
    }

    void CalculateGrowth()
    {
        growth = maxSize / ManageScore.totalScore;
    }
}
