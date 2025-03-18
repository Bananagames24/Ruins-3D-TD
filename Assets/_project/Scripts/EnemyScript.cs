using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public EnemySelect EnemyType = new EnemySelect();

    [Header("Enemy Stats")]
    public int Health;
    public int lifeCost;
    public float Speed;
    public int coinDrop;

    [Header("AI Movement")]
    public Camera m_Camera;
    public NavMeshAgent m_Agent;

    private void Start()
    {
        //select enemy type
        if (EnemyType == EnemySelect.BasicE)
        {
            Health = 50;
            lifeCost = 2;
            Speed = 1;
            coinDrop = 4;
        }
        else if (EnemyType == EnemySelect.SpeedE)
        {
            Health = 40;
            lifeCost = 2;
            Speed = 2;
            coinDrop = 5;
        }
        else if (EnemyType == EnemySelect.SlowE)
        {
            Health = 100;
            lifeCost = 5;
            Speed = 0.6f;
            coinDrop = 12;
        }
        else if (EnemyType == EnemySelect.TankE)
        {
            Health = 200;
            lifeCost = 10;
            Speed = 0.9f;
            coinDrop = 18;
        }
        else if (EnemyType == EnemySelect.SlowTankE)
        {
            Health = 400;
            lifeCost = 20;
            Speed = 0.5f;
            coinDrop = 25;
        }
        else if (EnemyType == EnemySelect.Boss1E)
        {
            Health = 2000;
            lifeCost = 50;
            Speed = 0.5f;
            coinDrop = 69;
        }
        else if (EnemyType == EnemySelect.Boss2E)
        {
            Health = 4000;
            lifeCost = 75;
            Speed = 0.4f;
            coinDrop = 101;
        }
        else if (EnemyType == EnemySelect.Boss3E)
        {
            Health = 8000;
            lifeCost = 100;
            Speed = 0.3f;
            coinDrop = 169;
        }
        m_Agent.speed = Speed;
    }


    void Update()
    {
        //move enemy to the closest point the enemy can get where the player clicks
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                m_Agent.SetDestination(hit.point);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Health -= other.GetComponent<BulletScript>().m_GunDamage;
            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("TowerBullet"))
        {
            Health -= other.GetComponent<TowerBulletScript>().m_TowerBulletDamage;
            if (Health <= 0)
            {
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

