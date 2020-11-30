using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float minimumDistance = 20.0f;

    public virtual bool CanInteract(Collider col)
    {
        GameObject collidingObject = col.gameObject;
        float distance = Vector3.Distance(transform.position, collidingObject.transform.position);
        return distance < minimumDistance;
    }

    public virtual void Interact()
    {
    
    }
    
}
