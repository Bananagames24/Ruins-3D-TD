using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Gravity = -9.81f;
    [SerializeField] private float m_JumpForce;

    Vector3 velocity;
    public CharacterController m_Controller;
    private Vector2 m_Input = Vector2.zero;

    void Start()
    {

    }

    void Update()
    {
        Vector3 direction = transform.right * m_Input.x + transform.forward * m_Input.y;
        m_Controller.Move(direction * m_Speed * Time.deltaTime);

        if(!m_Controller.isGrounded)
        {
            velocity.y += m_Gravity * Time.deltaTime;
        }else
        {
            velocity.y = -2f;
        }

        m_Controller.Move(velocity * Time.deltaTime);
    }

    public void OnMoveStop(InputAction.CallbackContext _context)
    {
        m_Input = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        m_Input = _context.ReadValue<Vector2>().normalized;
    }
}
