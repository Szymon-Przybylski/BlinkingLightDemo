using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    
    [SerializeField] private bool isGameShowcaseSetup = false;

    private CharacterController _characterController;

    private float _cameraPitch;
    private float _movementSpeed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _cameraPitch = 0.0f;
        _movementSpeed = 6.0f;

        if (isGameShowcaseSetup)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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
}
