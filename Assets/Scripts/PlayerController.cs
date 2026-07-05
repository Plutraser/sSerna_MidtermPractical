using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private int rotationSpeed = 12;

    [Header("Jump & Gravity")]
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpVelocity = 9f;
    [SerializeField] private int fallMultiplier = 5;
    private bool hasJumped;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    private CharacterController controller;
    private Camera cam;

    private float verticalVelocity;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }

        if (cameraTransform != null)
        {
            cam = cameraTransform.GetComponent<Camera>();
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 cameraRealtiveMoveDirection = (cameraRight * moveX + cameraForward * moveZ).normalized;

        bool falling = verticalVelocity < 0f && hasJumped;
        float gravityThisFrame = gravity;
        if (falling)
        {
            gravityThisFrame *= fallMultiplier;
        }
        verticalVelocity += gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if(verticalVelocity < 0f)
            {
                verticalVelocity = -2f;
                hasJumped = false;
            }
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpVelocity;
                hasJumped = true;
            }
        }

        if (cameraRealtiveMoveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(cameraRealtiveMoveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }


        Vector3 finalMove = cameraRealtiveMoveDirection * speed;
        controller.Move((finalMove + Vector3.up * verticalVelocity) * Time.deltaTime);
    }
}
