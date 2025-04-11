using UnityEngine;

public class LivesScript : MonoBehaviour
{
    private GameManager m_GameManager;

    private void Start()
    {
        m_GameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            m_GameManager.m_LivesCount -= other.GetComponent<EnemyScript>().m_LifeCost;
            Destroy(other.gameObject);
        }
    }
}
