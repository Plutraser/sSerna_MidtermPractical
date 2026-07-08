using UnityEngine;


public class CameraController : MonoBehaviour
{
    [Header("Target")]
    public Transform Target;
    public Vector3 FocusOffset = new Vector3(0f, 1.5f, 0f); //Overhead view

    [Header("Orbit")]
    public float Distance = 2.2f;
    public float SensitivityX = 3f;
    public float SensitivityY = 3f;
    public float MinPitch = -20f;
    public float MaxPitch = 60f;

    private float yaw;
    private float pitch = 15f;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// 
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
