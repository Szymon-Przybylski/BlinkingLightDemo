using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colliding");
    }

    private void OnTriggerStay(Collider other)
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (CanInteract(other))
        {
            Interact();
        }
    }

    protected override void Interact()
    {
        base.Interact();
        Debug.Log("no implementation, override redundant");
    }
}

