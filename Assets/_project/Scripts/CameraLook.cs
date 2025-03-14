using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    private Vector2 m_CamVector;
    private float xRotation = 0f;
    [SerializeField] private float m_sensitivity = 100f;

    [SerializeField] private Transform m_PlayerTransform;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        CamRotation();
    }

    private void CamRotation()
    {
        m_CamVector.x *= m_sensitivity * Time.fixedDeltaTime;
        m_CamVector.y *= m_sensitivity * Time.fixedDeltaTime;

        xRotation -= m_CamVector.y;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        m_PlayerTransform.Rotate(Vector3.up * m_CamVector.x);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_CamVector = context.ReadValue<Vector2>();
    }
}
