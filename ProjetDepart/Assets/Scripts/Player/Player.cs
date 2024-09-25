using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 100f; 
    [SerializeField] private float rotationSpeed = 0.5f;

    [Header("Inputs")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;   

    private CharacterController controller;
    private Transform cameraTransform;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main?.transform;
    }

    private void Update()
    {
        // Get directions.
        var relativeTransform = cameraTransform ?? transform;
        var forward = relativeTransform.forward;
        var right = relativeTransform.right;

        // Remove Y component from vectors.
        forward.y = 0;
        right.y = 0;

        //Apply gravity
        if (!controller.isGrounded)
        {
           controller.Move(Physics.gravity * Time.deltaTime);
        }

        // Calculate movement direction.
        var moveInput = moveAction.action.ReadValue<Vector2>();
        if (moveInput == Vector2.zero)
        {
            controller.Move(Vector3.zero);
        }
        else
        {
            var moveDirection = forward * moveInput.y + right * moveInput.x;
            var lookRotation = Quaternion.LookRotation(moveDirection);
            // Apply movement.
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);  
            controller.Move(forward * moveInput.y * (speed * Time.deltaTime));
            

        }

        if (jumpAction.action.IsPressed())
        {
           controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }


    }

}
