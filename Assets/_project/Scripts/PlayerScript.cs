using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    [Header("Player stats")]
    public int m_PlayerHealth;
    private bool m_IsDead;

    [Header("Player Shooting")]
    [SerializeField] private GameObject m_Gun;
    [SerializeField] private Transform m_BulletSpawnPostition;
    [SerializeField] private GameObject m_Bullet;
    public bool m_IsGunSelected;
    public bool m_IsHandSelected;
    private float m_FireRate;
    private bool m_Shoot;
    private bool m_ShootReady;

    [Header("Player Movement")]
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Gravity = -9.81f;
    [SerializeField] private float m_JumpForce = 5f;
    private bool m_Jump = false;

    [Header("Character Controller")]
    public CharacterController m_Controller;
    private Vector2 m_Input = Vector2.zero;
    Vector3 m_Velocity;

    [Header("Player UI")]
    public GameObject m_DeathScreen;

    private GameManager m_GameManager;

    private void Start()
    {
        m_PlayerHealth = 5;
        m_IsDead = false;
        m_FireRate = 1;
        m_ShootReady = true;
    }

    void Update()
    {
        HandleMovementAndJump();
        Shooting();
        Gun();

        if (m_PlayerHealth == 0)
        {
            m_IsDead = true;
        }

        if (m_IsDead)
        {
            m_DeathScreen.SetActive(true);
        }
        else if (!m_IsDead)
        {
            m_DeathScreen.SetActive(false);
        }
    }

        void HandleMovementAndJump()
        {
            Vector3 direction = transform.right * m_Input.x + transform.forward * m_Input.y;

            if (m_Controller.isGrounded)
            {
                if (m_Velocity.y < 0)
                {
                    m_Velocity.y = -2f;
                }

                if (m_Jump)
                {
                    m_Velocity.y = Mathf.Sqrt(m_JumpForce * -2f * m_Gravity);
                    m_Jump = false;
                }
            }
            else
            {
                m_Velocity.y += m_Gravity * Time.deltaTime;
            }

            //makes the player move in all directions
            //can only use m.controller.move 1 time in script or the character controller will bug with isgrounded
            Vector3 move = direction * m_Speed * Time.deltaTime + m_Velocity * Time.deltaTime;
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
            else { m_Shoot = false; }

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
        yield return new WaitForSeconds(m_FireRate);
        m_ShootReady = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            m_PlayerHealth --;
        }
    }
}
