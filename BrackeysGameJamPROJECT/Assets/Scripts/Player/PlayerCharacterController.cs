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
    }

    private void FixedUpdate()
    {
        SolveAndMovePlayer();
    }

    void SolveAndMovePlayer() 
    {
        movementVector = movementVectorInput.ReadValue<Vector2>();
        Vector3 direction = transform.TransformDirection(movementVector.x, 0, movementVector.y);

        direction = (direction * speed) * Time.fixedDeltaTime;
        characterController.SimpleMove(direction);
    }
}
