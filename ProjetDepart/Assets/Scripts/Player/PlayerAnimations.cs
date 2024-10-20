using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class PlayerAnimations : MonoBehaviour
{
    private static readonly int Blend = Animator.StringToHash("Blend");
    [Header("Animations")]
    [SerializeField,Range(0, 1)] private float walkThreshold = 0.1f;
    [SerializeField, Range(0, 1)] private float walkStartDamping = 0.3f;
    [SerializeField, Range(0, 1)] private float walkStopDamping = 0.15f;
    private Animator animator;
    private CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        var velocity = characterController.velocity;
        var normalizedSpeed = velocity.normalized.sqrMagnitude;

        if (normalizedSpeed > walkThreshold)
            animator.SetFloat(Blend, normalizedSpeed, walkStartDamping, Time.deltaTime);
        else if (normalizedSpeed < walkThreshold)
            animator.SetFloat(Blend, normalizedSpeed, walkStopDamping, Time.deltaTime);
    }

}
