using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Shooting")]
    [SerializeField] private GameObject m_Gun;
    [SerializeField] private Transform m_BulletSpawnPostition;
    [SerializeField] private GameObject m_Bullet;
    public bool m_IsGunSelected;
    public bool m_IsHandSelected;
    private bool m_Shoot;
    private bool m_ShootReady = true;

    [Header("Player Movement")]
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Gravity = -9.81f;
    [SerializeField] private float m_JumpForce = 5f;
    private bool m_Jump = false;

    [Header("Character Controller")]
    public CharacterController m_Controller;
    private Vector2 m_Input = Vector2.zero;
    Vector3 velocity;

    void Update()
    {
        HandleMovementAndJump();
        Shooting();
        Gun();
    }

    void HandleMovementAndJump()
    {
        Vector3 direction = transform.right * m_Input.x + transform.forward * m_Input.y;

        if (m_Controller.isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Small value to keep the character grounded
            }

            if (m_Jump)
            {
                velocity.y = Mathf.Sqrt(m_JumpForce * -2f * m_Gravity);
                m_Jump = false;
            }
        }
        else
        {
            velocity.y += m_Gravity * Time.deltaTime;
        }

        Vector3 move = direction * m_Speed * Time.deltaTime + velocity * Time.deltaTime;
        m_Controller.Move(move);
    }

    void Shooting()
    {
        if (m_Shoot && m_IsGunSelected)
        {
            m_Shoot = false;
            if (m_ShootReady)
            {
                m_ShootReady = false;
                StartCoroutine(ShootingTimer());
            }
        }
    }
    void Gun()
    {
        if (m_IsGunSelected)
        {
            m_Gun.SetActive(true);
        }
        else
        {
            m_Gun.SetActive(false);
        }
    }

    public void OnMoveStop(InputAction.CallbackContext _context)
    {
        m_Input = Vector2.zero;
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        m_Input = _context.ReadValue<Vector2>().normalized;
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.performed && m_Controller.isGrounded)
        {
            m_Jump = true;
        }
    }

    public void Shoot(InputAction.CallbackContext _context)
    {
        m_Shoot = true;
    }

    IEnumerator ShootingTimer()
    {
        Instantiate(m_Bullet, m_BulletSpawnPostition.position, Quaternion.LookRotation(transform.forward), null);
        yield return new WaitForSeconds(1);
        m_ShootReady = true;
    }

    

}
