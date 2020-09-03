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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PushPlayer(other);
            SendOutEvent();
        }
        Debug.Log(other.tag);
    }
    

    void SendOutEvent()
    {
            OnPLayerHit?.Invoke(damage);
    }

    void PushPlayer(Collider other)
    {
        Vector3 relativePlayerPosition = -transform.position;
        other.attachedRigidbody.AddForce(relativePlayerPosition.normalized * pushForce);
    }

}
