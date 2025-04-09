using UnityEngine;

public class UpgradeSell : MonoBehaviour
{
    [SerializeField] private bool m_IsUpgrade;
    [SerializeField] private bool m_IsSell;
    [SerializeField] private TowerScript m_TowerScript;
    private GameManager m_GameManager;

    private void Start()
    {
        m_TowerScript = GetComponentInParent<TowerScript>();
        m_GameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_IsUpgrade && m_TowerScript.m_TowerCurrentUpgrade <= 5 && m_GameManager.m_Coins >= m_TowerScript.m_TowerCurrentCost)
            {
                m_TowerScript.m_TowerCurrentUpgrade++;
                m_TowerScript.SelectedTower();
            }
            else if (m_IsSell)
            {
                m_TowerScript.m_TowerCurrentUpgrade = 0;
                m_TowerScript.SelectedTower();
            }
        }
    }
}