using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    public float pushForce = 300;
    public float damage = 1;

    public static event Action<float> OnPLayerHit;
    void Start()
    {
        
    }

        void Update()
    {
        
    }

    /// <summary>
    /// When player collides with trigger run push and event methods.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PushPlayer(other);
            SendOutEvent();
        }
    }
    
    /// <summary>
    /// Sends out the OnPlayerHit event.
    /// </summary>
    void SendOutEvent()
    {
            OnPLayerHit?.Invoke(damage);
    }

    /// <summary>
    /// Pushes the player back from the monster.
    /// </summary>
    /// <param name="other"></param>
    void PushPlayer(Collider other)
    {
        Vector3 relativePlayerPosition = -transform.position;
        other.attachedRigidbody.AddForce(relativePlayerPosition.normalized * pushForce);
    }

}
