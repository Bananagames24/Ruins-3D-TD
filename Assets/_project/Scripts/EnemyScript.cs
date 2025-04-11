using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public EnemySelect EnemyType = new EnemySelect();

    [Header("Enemy Stats")]
    public int m_Health;
    public int m_LifeCost;
    public float m_Speed;
    public int m_CoinDrop;
    public Slider m_HealthBar;

    [Header("AI Movement")]
    public NavMeshAgent m_Agent;

    private GameManager m_GameManager;

    private float m_SlowSpeed;
    private bool m_FireActive;
    private int m_FireDamage;
    public ParticleSystem m_EnemyDeathEffect;
    public ParticleSystem m_FireEffect;



    private void Start()
    {

        m_GameManager = FindFirstObjectByType<GameManager>();
        //select enemy type
        if (EnemyType == EnemySelect.BasicE)
        {
            m_Health = 40;
            m_LifeCost = 2;
            m_Speed = 4f;
            m_CoinDrop = 7;
        }
        else if (EnemyType == EnemySelect.SpeedE)
        {
            m_Health = 25;
            m_LifeCost = 2;
            m_Speed = 6f;
            m_CoinDrop = 12;
        }
        else if (EnemyType == EnemySelect.SlowE)
        {
            m_Health = 100;
            m_LifeCost = 5;
            m_Speed = 3f;
            m_CoinDrop = 18;
        }
        else if (EnemyType == EnemySelect.TankE)
        {
            m_Health = 175;
            m_LifeCost = 10;
            m_Speed = 2f;
            m_CoinDrop = 23;
        }
        else if (EnemyType == EnemySelect.SlowTankE)
        {
            m_Health = 250;
            m_LifeCost = 20;
            m_Speed = 1.8f;
            m_CoinDrop = 32;
        }
        else if (EnemyType == EnemySelect.Boss1E)
        {
            m_Health = 1250;
            m_LifeCost = 50;
            m_Speed = 1.6f;
            m_CoinDrop = 153;
        }
        else if (EnemyType == EnemySelect.Boss2E)
        {
            m_Health = 2500;
            m_LifeCost = 75;
            m_Speed = 1.4f;
            m_CoinDrop = 221;
        }
        else if (EnemyType == EnemySelect.Boss3E)
        {
            m_Health = 400;
            m_LifeCost = 100;
            m_Speed = 1.2f;
            m_CoinDrop = 351;
        }
        m_Agent.speed = m_Speed;
        m_HealthBar.maxValue = m_Health;
        m_HealthBar.value = m_Health;
        //move enemy to the end point
        m_Agent.SetDestination(m_GameManager.m_EndPoint.position);

        if (m_Health <= 0)
        {
            m_GameManager.m_Coins += m_CoinDrop;
            Destroy(gameObject);
        }

        
    }
    private void Update()
    {
        if (m_Health <= 0)
        {
            m_GameManager.m_Coins += m_CoinDrop;
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            m_Health -= other.GetComponent<BulletScript>().m_GunDamage;
            m_HealthBar.value = m_Health;
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("TowerBullet"))
        {
            m_Health -= other.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            m_HealthBar.value = m_Health;
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("SlowTowerBullet"))
        {
            m_Health -= other.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            m_HealthBar.value = m_Health;
            m_SlowSpeed = other.gameObject.GetComponent<TowerBulletScript>().m_SlowSpeed;
            StartCoroutine(SlowEffect());
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("FireTowerBullet"))
        {
            m_Health -= other.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            m_HealthBar.value = m_Health;
            m_FireDamage = other.gameObject.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            m_FireActive = true;
            StartCoroutine(FireEffect());
            if (m_Health <= 0)
            {
                m_GameManager.m_Coins += m_CoinDrop;
                Destroy(gameObject);
            }
        }
    }

    IEnumerator FireEffect()
    {
        m_FireEffect.Play();
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
        yield return new WaitForSeconds(1f);
        m_Health -= m_FireDamage;
        m_HealthBar.value = m_Health;
    }

    IEnumerator SlowEffect()
    {
        m_Agent.speed = m_Speed * m_SlowSpeed;
        yield return new WaitForSeconds(10f);
        m_Agent.speed = m_Speed;
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

