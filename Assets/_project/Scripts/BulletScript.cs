using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int m_GunDamage;
    public float m_BulletSpeed;
    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private Transform m_PlayerCameraTransform;
    private Vector3 direction;

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 5f);
        m_PlayerCameraTransform = FindAnyObjectByType<Camera>().transform;

        RaycastHit hit;
        if (Physics.Raycast(m_PlayerCameraTransform.position, m_PlayerCameraTransform.forward, out hit))
        {
            direction = (hit.point - transform.position).normalized;
        }
        else
        {
            direction = m_PlayerCameraTransform.forward;
        }

        m_Rigidbody.linearVelocity = direction * m_BulletSpeed;
    }

    private void FixedUpdate()
    {
        Debug.Log("Bullet Speed: " + m_Rigidbody.linearVelocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

