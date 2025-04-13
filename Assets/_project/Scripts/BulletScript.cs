using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int m_GunDamage;
    public float m_BulletSpeed;
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private Transform m_PlayerCameraTransform;
    private Vector3 m_Direction;
    [SerializeField] private LayerMask m_IgnoreLayer;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        m_PlayerCameraTransform = FindAnyObjectByType<Camera>().transform;

        // Shoots a bullet where the player looks at
        RaycastHit hit;
        if (Physics.Raycast(m_PlayerCameraTransform.position, m_PlayerCameraTransform.forward, out hit, Mathf.Infinity, ~m_IgnoreLayer))
        {
            m_Direction = (hit.point - transform.position).normalized;
        }
        else
        {
            m_Direction = m_PlayerCameraTransform.forward;
        }

        m_Rigidbody.linearVelocity = m_Direction * m_BulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

