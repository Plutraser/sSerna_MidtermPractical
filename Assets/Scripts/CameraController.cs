using UnityEngine;


public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform Target;
    public Vector3 FocusOffset = new Vector3(0f, 1.3f, 0f); //Overhead view

    [Header("Orbit")]
    public float Distance = 2.2f;
    public float SensitivityX = 3f;
    public float SensitivityY = 3f;
    public float MinPitch = -20f;
    public float MaxPitch = 60f;

    private float yaw;
    private float pitch = 15f;

    /// <summary>
    /// Locks the cursor onto the screen and doesnt allow it to be visible. Need it to be locked so the player can rotate the screen with mouse.
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// If the target isnt detected, returns. This controls the camera movement, using the mouse's directions to rotate the screen.
    /// </summary>
    void LateUpdate()
    {
        if (Target == null)
        {
            return;
        }

        yaw += Input.GetAxis("Mouse X") * SensitivityX;
        pitch += Input.GetAxis("Mouse Y") * SensitivityY;
        pitch = Mathf.Clamp(pitch, MinPitch, MaxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 focusPoint = Target.position + FocusOffset;
        Vector3 desiredPosition = focusPoint - rotation * Vector3.forward * Distance;

        transform.position = desiredPosition;
        transform.rotation = rotation;
    }
}
