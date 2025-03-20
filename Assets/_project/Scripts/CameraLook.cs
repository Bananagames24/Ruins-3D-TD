using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    private Vector2 m_CamVector;
    private float m_XRotation = 0f;
    [SerializeField] private float m_sensitivity = 100f;

    [SerializeField] private Transform m_PlayerTransform;

    private void Start()
    {
        //makes the cursor invisible and locks it in the middle of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        CamRotation();
    }

    //lets the player look around
    private void CamRotation()
    {
        m_CamVector.x *= m_sensitivity * Time.fixedDeltaTime;
        m_CamVector.y *= m_sensitivity * Time.fixedDeltaTime;

        m_XRotation -= m_CamVector.y;

        m_XRotation = Mathf.Clamp(m_XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
        m_PlayerTransform.Rotate(Vector3.up * m_CamVector.x);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        m_CamVector = context.ReadValue<Vector2>();
    }
}
