using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public EnemySelect EnemyType = new EnemySelect();

    [Header("Enemy Stats")]
    public int m_Health;
    public int m_LifeCost;
    public float m_Speed;
    public int m_CoinDrop;

    [Header("AI Movement")]
    public Camera m_Camera;
    public NavMeshAgent m_Agent;

    private GameManager m_GameManager;

    private void Start()
    {
        m_GameManager = FindFirstObjectByType<GameManager>();
        //select enemy type
        if (EnemyType == EnemySelect.BasicE)
        {
            m_Health = 50;
            m_LifeCost = 2;
            m_Speed = 1.5f;
            m_CoinDrop = 6;
        }
        else if (EnemyType == EnemySelect.SpeedE)
        {
            m_Health = 40;
            m_LifeCost = 2;
            m_Speed = 3f;
            m_CoinDrop = 10;
        }
        else if (EnemyType == EnemySelect.SlowE)
        {
            m_Health = 100;
            m_LifeCost = 5;
            m_Speed = 1f;
            m_CoinDrop = 15;
        }
        else if (EnemyType == EnemySelect.TankE)
        {
            m_Health = 200;
            m_LifeCost = 10;
            m_Speed = 0.9f;
            m_CoinDrop = 22;
        }
        else if (EnemyType == EnemySelect.SlowTankE)
        {
            m_Health = 400;
            m_LifeCost = 20;
            m_Speed = 0.7f;
            m_CoinDrop = 28;
        }
        else if (EnemyType == EnemySelect.Boss1E)
        {
            m_Health = 2000;
            m_LifeCost = 50;
            m_Speed = 0.6f;
            m_CoinDrop = 69;
        }
        else if (EnemyType == EnemySelect.Boss2E)
        {
            m_Health = 4000;
            m_LifeCost = 75;
            m_Speed = 0.5f;
            m_CoinDrop = 101;
        }
        else if (EnemyType == EnemySelect.Boss3E)
        {
            m_Health = 8000;
            m_LifeCost = 100;
            m_Speed = 0.4f;
            m_CoinDrop = 169;
        }
        m_Agent.speed = m_Speed;

        //move enemy to the end point
        m_Agent.SetDestination(m_GameManager.m_EndPoint.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            m_Health -= other.GetComponent<BulletScript>().m_GunDamage;
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("TowerBullet"))
        {
            m_Health -= other.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }
    }

}

public enum EnemySelect
{
    BasicE,
    SpeedE,
    SlowE,
    TankE,
    SlowTankE,
    Boss1E,
    Boss2E,
    Boss3E
};

