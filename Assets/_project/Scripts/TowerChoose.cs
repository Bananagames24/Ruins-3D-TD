using UnityEngine;

public class TowerChoose : MonoBehaviour
{
    [Header("Tower Type")]
    public TowerSelect TowerType = new TowerSelect();
    public string m_TowerName;


    private GameManager m_GameManager;
    private TowerScript m_TowerScript;

    private void Start()
    {
        m_TowerScript = GetComponentInParent<TowerScript>();
        m_TowerName = TowerType.ToString();
        m_GameManager = FindFirstObjectByType<GameManager>();
    }

    void TowerUpdate()
    {
        m_TowerScript.m_Ruins.SetActive(false);
        m_TowerScript.m_TowerUIStart.SetActive(false);
        m_TowerScript.m_TowerUIUpgrade.SetActive(true);
        m_TowerScript.m_TowerBuildEffect.Play();
        m_TowerScript.m_TowerCurrentUpgrade = 1;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (m_TowerName == "ArcherT")
            {
                m_TowerScript.m_TowerCost = 35;
                if(m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "ArcherT";
                    TowerUpdate();
                    m_TowerScript.m_ArcherTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();

                }
                else { }
                
            }
            else if (m_TowerName == "MagicT")
            {
                m_TowerScript.m_TowerCost = 50;
                if (m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "MagicT";
                    TowerUpdate();
                    m_TowerScript.m_MagicTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();

                }
                else { }
            }
            else if (m_TowerName == "CannonT")
            {
                m_TowerScript.m_TowerCost = 60;
                if (m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "CannonT";
                    TowerUpdate();
                    m_TowerScript.m_CannonTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();
                }
                else { }
                
            }
            else if (m_TowerName == "FireT")
            {
                m_TowerScript.m_TowerCost = 120;
                if (m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "FireT";
                    TowerUpdate();
                    m_TowerScript.m_FireTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();
                }
                else { }
                
            }
            else if (m_TowerName == "SlowT")
            {
                m_TowerScript.m_TowerCost = 50;
                if (m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "SlowT";
                    TowerUpdate();
                    m_TowerScript.m_SlowTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();
                }
                else { }
                
            }
            else if (m_TowerName == "MoneyT")
            {
                m_TowerScript.m_TowerCost = 150;
                if (m_GameManager.m_Coins >= m_TowerScript.m_TowerCost)
                {
                    m_TowerScript.m_TowerSellCost += m_TowerScript.m_TowerCost;
                    m_GameManager.m_Coins -= m_TowerScript.m_TowerCost;
                    m_TowerScript.m_TowerSelected = "MoneyT";
                    TowerUpdate();
                    m_TowerScript.m_MoneyTLVL1.SetActive(true);
                    m_TowerScript.SelectedTower();
                }
                else { }
                
            }
        }
    }
}
