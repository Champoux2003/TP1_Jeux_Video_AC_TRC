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

        Vector3 move = Vector3.zero;
        move.y += controller.velocity.y;


        //Apply gravity
        if (!controller.isGrounded)
        {
            move += Physics.gravity;
        }
        //Calculate jump
        else if (jumpAction.action.IsPressed())
        {
            move.y = jumpForce;
        }
        var moveInput = moveAction.action.ReadValue<Vector2>();
        var moveDirection = forward * moveInput.y + right * moveInput.x;
        var lookRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        move += moveDirection * speed;
        controller.Move(move * Time.deltaTime);
    }
}
