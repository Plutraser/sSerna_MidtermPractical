using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private int rotationSpeed = 12;

    [Header("Jump & Gravity")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private float jumpVelocity = 9f;
    [SerializeField] private int fallMultiplier = 5;
    private bool hasJumped;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    private CharacterController controller;
    private Camera cam;

    private float verticalVelocity;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
