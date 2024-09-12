using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerCharacterController : MonoBehaviour
{    
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    [Header("Input")]
    [SerializeField] private InputAction movementVectorInput;
    [SerializeField] private InputAction sprintKey;
    [SerializeField] private InputAction jumpKey;

    [SerializeField] private Camera fpCamera;

    private Vector2 movementVector;
    private CharacterController characterController;
    private float speed;

    private void Start()
    {
        movementVectorInput.Enable();
        sprintKey.Enable();
        jumpKey.Enable();

        TryGetComponent(out characterController);

        speed = walkSpeed;

        fpCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        SolveAndMovePlayer();
    }

    void SolveAndMovePlayer() 
    {
        movementVector = movementVectorInput.ReadValue<Vector2>();
        Vector3 direction = transform.TransformDirection(movementVector.x, 0, movementVector.y);

        if (sprintKey.IsPressed()) { speed = sprintSpeed; fpCamera.fieldOfView = 60f; } else { speed = walkSpeed; fpCamera.fieldOfView = 55f; }

        direction = (direction * speed) * Time.fixedDeltaTime;
        characterController.SimpleMove(direction);
    }
}
