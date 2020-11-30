using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding");
    }

    public override bool CanInteract(Collider col)
    {
        Debug.Log("called CanInteract");
        return base.CanInteract(col);
    }
    

    public override void Interact()
    {
        base.Interact();
        Debug.Log("called Interact");
    }
}

