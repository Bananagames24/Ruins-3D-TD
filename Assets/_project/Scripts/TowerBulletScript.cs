using System;
using UnityEngine;

public class TowerBulletScript : MonoBehaviour
{
    [SerializeField] private float m_TowerBulletSpeed;
    private Vector3 m_Bulletgoplace;
    public int m_TowerBulletDamage;
    private TowerScript m_TowerShoot;

    public float m_SlowSpeed;

    private void Start()
    {
        m_TowerShoot = GetComponentInParent<TowerScript>();
        Destroy(gameObject, 4f);

    }

    private void Update()
    {
        m_SlowSpeed = m_TowerShoot.m_SlowEffect;
        m_TowerBulletDamage = m_TowerShoot.m_TowerDamage;
        if (m_TowerShoot.m_EnemiesInRange != null)
        {
            m_Bulletgoplace = m_TowerShoot.m_EnemiesInRange[0].transform.position;
            transform.position = Vector3.MoveTowards(transform.position, m_Bulletgoplace, m_TowerBulletSpeed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            Destroy(gameObject);
        }
    }
}
