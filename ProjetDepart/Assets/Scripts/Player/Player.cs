using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float gravity = 30.0f;
    [SerializeField] private float rotationSpeed = 0.5f;

    [Header("Inputs")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Invincibility")]
    [SerializeField] private float invincibilityDuration = 0.5f;

    private bool isInvincible = false;
    private CharacterController controller;
    private Transform cameraTransform;

    private float verticalMovement = 0f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main?.transform;
    }

    private void Update()
    {
        Vector3 move = PlayerSurfaceMovement();

        PlayerVerticalMovement();

        controller.Move(move * Time.deltaTime);
    }


    private Vector3 PlayerSurfaceMovement()
    {
        var relativeTransform = cameraTransform ?? transform;
        var forward = relativeTransform.forward;
        var right = relativeTransform.right;

        forward.y = 0;
        right.y = 0;

        var moveInput = moveAction.action.ReadValue<Vector2>();
        var moveDirection = forward * moveInput.y + right * moveInput.x;

        if(moveDirection.magnitude > 0.1f)
        {
            var lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 move = moveDirection * speed;
        return move;
    }

    private void PlayerVerticalMovement()
    {
        if (controller.isGrounded)
        {
            verticalMovement = -gravity * Time.deltaTime;
        }
        else
        {
            verticalMovement -= gravity * Time.deltaTime;
        }

        if (jumpAction.action.IsPressed() && controller.isGrounded)
        {
            verticalMovement = jumpForce;
        }

        controller.Move(new Vector3(0, verticalMovement, 0) * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Alien>() is not null && !isInvincible)
        {
            if(transform.position.y > collision.transform.position.y)
            {
                Finder.EventChannels.PublishPlayerHitAlien();
            }
            else
            {
                StartCoroutine(EnableInvicibility());
            }
        }   
    }

    private IEnumerator EnableInvicibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
