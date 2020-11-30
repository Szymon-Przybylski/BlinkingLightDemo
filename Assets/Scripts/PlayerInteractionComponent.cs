using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerInteractionComponent : Interactable
{
    [SerializeField] private Transform playerCamera;

    private CharacterController _characterController;
    private ObjectScript _objectScript;

    private float _cameraPitch;
    private float _movementSpeed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _cameraPitch = 0.0f;
        _movementSpeed = 6.0f;
        
    }
    private void Update()
    {
        UpdateCameraOnMouseLook();
        UpdateMovementOnKeyboardInput();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGameOnEscapeKeyPress();
        }
    }

    private void UpdateCameraOnMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        _cameraPitch -= mouseDelta.y;
        _cameraPitch = Mathf.Clamp(_cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;
        
        transform.Rotate(Vector3.up * mouseDelta.x);
    }
    private void UpdateMovementOnKeyboardInput()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementInput.Normalize();
        
        Vector3 velocity = (transform.forward * movementInput.y + transform.right * movementInput.x) * _movementSpeed;
        _characterController.Move(velocity * Time.deltaTime);
    }
    private void ExitGameOnEscapeKeyPress()
    {
        Application.Quit();
    }

    private void OnTriggerStay(Collider collider)
    {
        _objectScript = collider.GetComponent<ObjectScript>();
        if (_objectScript.CanInteract(collider))
        {
            InteractWithInteractable();
        }
    }

    private void InteractWithInteractable()
    {
        _objectScript.Interact();
        Debug.Log("interacted from player");
    }
    
    
}
