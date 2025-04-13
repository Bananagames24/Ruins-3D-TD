using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    private Vector2 m_CamVector;
    private float m_XRotation = 0f;
    [Range(0.1f, 15.0f)]
    [SerializeField] private float m_sensitivity;

    [SerializeField] private Transform m_PlayerTransform;

    public GameObject m_PauseMenu;
    public GameObject m_GameMenu;

    private void Start()
    {
        //makes the cursor invisible and locks it in the middle of the screen
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        m_PauseMenu.SetActive(false);
        m_GameMenu.SetActive(true);
    }

    void LateUpdate()
    {
        if(!m_PauseMenu.activeSelf)CamRotation();
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

    private void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (m_PauseMenu.activeSelf)
            {
                m_PauseMenu.SetActive(false);
                m_GameMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
            }
            else
            {
                m_PauseMenu.SetActive(true);
                m_GameMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        m_CamVector = context.ReadValue<Vector2>();
    }
}
