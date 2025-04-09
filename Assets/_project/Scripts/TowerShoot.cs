using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public SphereCollider m_RangeCollider;
    public GameObject m_TowerBulletPrefab;
    public Transform m_TowerBulletSpawn;

    private TowerScript m_TowerScript;
    private bool m_ShootReady;

    private void Start()
    {
        m_TowerScript = GetComponentInParent<TowerScript>();
        m_ShootReady = true;
    }

    void Update()
    {
        m_RangeCollider.radius = m_TowerScript.m_TowerRange;

        if (m_ShootReady && m_TowerScript.m_EnemiesInRange.Count > 0)
        {
            Shoot();
            Invoke(nameof(ShootTimerTest),m_TowerScript.m_TowerFireRate);
            m_ShootReady = false;
        }
    }

    void Shoot()
    {
        Instantiate(m_TowerBulletPrefab, m_TowerBulletSpawn);
    }

    void ShootTimerTest()
    {
        
        m_ShootReady = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            m_TowerScript.m_EnemiesInRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            m_TowerScript.m_EnemiesInRange.Remove(collision.gameObject);
        }
    }
}