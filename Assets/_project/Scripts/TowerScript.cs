using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class TowerScript : MonoBehaviour
{
    [Header("Tower Type")]
    public string m_TowerSelected;

    [Header("Tower Stats")]
    public int m_TowerDamage;
    public float m_TowerRange;
    public float m_TowerFireRate;
    public int m_TowerCost;
    public int m_Moneyfarming;
    public float m_SlowEffect;
    public bool m_MoneyFarmingActive;

    [Header("Tower Components")]
    public GameObject m_TowerUIStart;
    public GameObject m_TowerUIUpgrade;
    public GameObject m_TowerUISell;
    public GameObject m_TowerUIStats;
    public TextMeshPro m_TowerUIUpgradeText;
    public TextMeshPro m_TowerUIsellText;
    public TextMeshPro m_TowerUIStatsText;
    public ParticleSystem m_TowerBuildEffect;

    [Header("Tower Prefabs")]
    public GameObject m_Ruins;

    [Header("Archer Tower")]
    public GameObject m_ArcherTLVL1;
    public GameObject m_ArcherTLVL2;
    public GameObject m_ArcherTLVL3;
    public GameObject m_ArcherTLVL4;
    public GameObject m_ArcherTLVL5;

    [Header("Magic Tower")]
    public GameObject m_MagicTLVL1;
    public GameObject m_MagicTLVL2;
    public GameObject m_MagicTLVL3;
    public GameObject m_MagicTLVL4;
    public GameObject m_MagicTLVL5;

    [Header("Cannon Tower")]
    public GameObject m_CannonTLVL1;
    public GameObject m_CannonTLVL2;
    public GameObject m_CannonTLVL3;
    public GameObject m_CannonTLVL4;
    public GameObject m_CannonTLVL5;

    [Header("Fire Tower")]
    public GameObject m_FireTLVL1;
    public GameObject m_FireTLVL2;
    public GameObject m_FireTLVL3;
    public GameObject m_FireTLVL4;
    public GameObject m_FireTLVL5;

    [Header("Slow Tower")]
    public GameObject m_SlowTLVL1;
    public GameObject m_SlowTLVL2;
    public GameObject m_SlowTLVL3;
    public GameObject m_SlowTLVL4;
    public GameObject m_SlowTLVL5;

    [Header("Money Tower")]
    public GameObject m_MoneyTLVL1;
    public GameObject m_MoneyTLVL2;
    public GameObject m_MoneyTLVL3;
    public GameObject m_MoneyTLVL4;
    public GameObject m_MoneyTLVL5;

    [Header("Tower Upgrades")]
    public int m_TowerCurrentUpgrade;
    public int m_TowerCurrentCost;
    public int m_TowerSellCost;

    private GameManager m_GameManager;
    public List<GameObject> m_EnemiesInRange = new List<GameObject>();

    void Start()
    {
        m_TowerSelected = "Ruins";
        m_TowerCurrentUpgrade = 1;
        m_GameManager = FindFirstObjectByType<GameManager>();
        m_Moneyfarming = 0;
        Ruins();
    }

    void Update()
    {
        m_TowerUIUpgradeText.text = "Upgrade:\n" +  m_TowerCurrentCost;
        m_TowerUIsellText.text = "Sell:\n" + m_TowerSellCost * 0.8;
        CleanUpEnemiesInRange();

    }

    private void CleanUpEnemiesInRange()
    {
        for (int i = m_EnemiesInRange.Count - 1; i >= 0; i--)
        {
            if (m_EnemiesInRange[i] == null)
            {
                m_EnemiesInRange.RemoveAt(i);
            }
        }
    }

    public void UpdateStats()
    {
        m_TowerUIStatsText.text = "Tower: " + m_TowerSelected + "\nDamage: " + m_TowerDamage + "\nRange: " + m_TowerRange + "\nFire Rate p/s: " + 1/m_TowerFireRate;
    }

    public void SelectedTower()
    {
        //Archer Tower
        if (m_TowerSelected == "ArcherT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 45;
                    m_TowerDamage = 3;
                    m_TowerRange = 20;
                    m_TowerFireRate = 0.5f;
                    UpdateStats();

                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 75;
                        m_TowerDamage = 5;
                        m_TowerRange = 20;
                        m_TowerFireRate = 0.4f;
                        m_ArcherTLVL1.SetActive(false);
                        m_ArcherTLVL2.SetActive(true);
                        UpdateStats();
                    }
                    
                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 150;
                        m_TowerDamage = 8;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 0.4f;
                        m_ArcherTLVL2.SetActive(false);
                        m_ArcherTLVL3.SetActive(true);
                        UpdateStats();
                    }
                    
                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 220;
                        m_TowerDamage = 10;
                        m_TowerRange = 20*1.35f;
                        m_TowerFireRate = 0.4f;
                        m_ArcherTLVL3.SetActive(false);
                        m_ArcherTLVL4.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerDamage = 10;
                        m_TowerRange = 20*1.35f;
                        m_TowerFireRate = 0.25f;
                        m_ArcherTLVL4.SetActive(false);
                        m_ArcherTLVL5.SetActive(true);
                        UpdateStats();
                    }

                    break;
            }
        }
        //Magic Tower
        else if (m_TowerSelected == "MagicT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 100;
                    m_TowerDamage = 10;
                    m_TowerRange = 20*1.1f;
                    m_TowerFireRate = 1;
                    UpdateStats();

                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 175;
                        m_TowerDamage = 15;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 1;
                        m_MagicTLVL1.SetActive(false);
                        m_MagicTLVL2.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 250;
                        m_TowerDamage = 25;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 0.8f;
                        m_MagicTLVL2.SetActive(false);
                        m_MagicTLVL3.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 350;
                        m_TowerDamage = 35;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 0.8f;
                        m_MagicTLVL3.SetActive(false);
                        m_MagicTLVL4.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerDamage = 50;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 0.667f;
                        m_MagicTLVL4.SetActive(false);
                        m_MagicTLVL5.SetActive(true);
                        UpdateStats();
                    }

                    break;
            }
        }
        //Cannon Tower
        else if (m_TowerSelected == "CannonT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 120;
                    m_TowerDamage = 30;
                    m_TowerRange = 20;
                    m_TowerFireRate = 2.5f;
                    UpdateStats();

                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 200;
                        m_TowerDamage = 40;
                        m_TowerRange = 20*1.3f;
                        m_TowerFireRate = 1.667f;
                        m_CannonTLVL1.SetActive(false);
                        m_CannonTLVL2.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 275;
                        m_TowerDamage = 40;
                        m_TowerRange = 20*1.3f;
                        m_TowerFireRate = 1.25f;
                        m_CannonTLVL2.SetActive(false);
                        m_CannonTLVL3.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 350;
                        m_TowerDamage = 50;
                        m_TowerRange = 20*1.3f;
                        m_TowerFireRate = 1;
                        m_CannonTLVL3.SetActive(false);
                        m_CannonTLVL4.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerDamage = 80;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 1;
                        m_CannonTLVL4.SetActive(false);
                        m_CannonTLVL5.SetActive(true);
                        UpdateStats();
                    }

                    break;
            }
        }
        //Fire Tower
        else if (m_TowerSelected == "FireT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 180;
                    m_TowerDamage = 4;
                    m_TowerRange = 20*1.2f;
                    m_TowerFireRate = 5;
                    UpdateStats();

                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 270;
                        m_TowerDamage = 4;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 2.5f;
                        m_FireTLVL1.SetActive(false);
                        m_FireTLVL2.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 400;
                        m_TowerDamage = 13;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 2.5f;
                        m_FireTLVL2.SetActive(false);
                        m_FireTLVL3.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 550;
                        m_TowerDamage = 13;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 1.25f;
                        m_FireTLVL3.SetActive(false);
                        m_FireTLVL4.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerDamage = 40;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 1.25f;
                        m_FireTLVL4.SetActive(false);
                        m_FireTLVL5.SetActive(true);
                        UpdateStats();
                    }

                    break;
            }
        }
        //Slow Tower
        else if (m_TowerSelected == "SlowT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 75;
                    m_TowerDamage = 1;
                    m_TowerRange = 20*1.2f;
                    m_TowerFireRate = 1.43f;
                    m_SlowEffect = 0.7f;
                    UpdateStats();

                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 150;
                        m_TowerDamage = 4;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 1;
                        m_SlowEffect = 0.7f;
                        m_SlowTLVL1.SetActive(false);
                        m_SlowTLVL2.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 220;
                        m_TowerDamage = 8;
                        m_TowerRange = 20*1.2f;
                        m_TowerFireRate = 1;
                        m_SlowEffect = 0.6f;
                        m_SlowTLVL2.SetActive(false);
                        m_SlowTLVL3.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 350;
                        m_TowerDamage = 8;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 0.83f;
                        m_SlowEffect = 0.6f;
                        m_SlowTLVL3.SetActive(false);
                        m_SlowTLVL4.SetActive(true);
                        UpdateStats();
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerDamage = 10;
                        m_TowerRange = 20*1.5f;
                        m_TowerFireRate = 0.83f;
                        m_SlowEffect = 0.5f;
                        m_SlowTLVL4.SetActive(false);
                        m_SlowTLVL5.SetActive(true);
                        UpdateStats();
                    }

                    break;
            }
        }
        //Money Tower
        else if (m_TowerSelected == "MoneyT")
        {
            switch (m_TowerCurrentUpgrade)
            {
                case 0:
                    Ruins();

                    break;

                case 1:
                    m_TowerCurrentCost = 220;
                    m_MoneyFarmingActive = true;
                    m_Moneyfarming += 1;
                    m_TowerUIStatsText.text = "Money Farm"+"\nMoney Per Second: " + m_Moneyfarming;
                    StartCoroutine(MoneyFarming());


                    break;
                case 2:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 360;
                        m_Moneyfarming += 1;
                        m_MoneyTLVL1.SetActive(false);
                        m_MoneyTLVL2.SetActive(true);
                        m_TowerUIStatsText.text = "Money Farm" + "\nMoney Per Second: " + m_Moneyfarming;
                    }

                    break;
                case 3:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 420;
                        m_Moneyfarming += 1;
                        m_MoneyTLVL2.SetActive(false);
                        m_MoneyTLVL3.SetActive(true);
                        m_TowerUIStatsText.text = "Money Farm" + "\nMoney Per Second: " + m_Moneyfarming;
                    }

                    break;
                case 4:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_TowerCurrentCost = 550;
                        m_Moneyfarming += 1;
                        m_MoneyTLVL3.SetActive(false);
                        m_MoneyTLVL4.SetActive(true);
                        m_TowerUIStatsText.text = "Money Farm" + "\nMoney Per Second: " + m_Moneyfarming;
                    }

                    break;
                case 5:
                    if (m_GameManager.m_Coins >= m_TowerCurrentCost)
                    {
                        m_GameManager.m_Coins -= m_TowerCurrentCost;
                        m_Moneyfarming += 1;
                        m_MoneyTLVL4.SetActive(false);
                        m_MoneyTLVL5.SetActive(true);
                        m_TowerUIStatsText.text = "Money Farm" + "\nMoney Per Second: " + m_Moneyfarming;
                    }

                    break;
            }
        }
    }

    //resets tower back to ruins
    private void Ruins()
    {
        m_TowerSelected = "Ruins";
        m_Ruins.SetActive(true);

        m_ArcherTLVL1.SetActive(false);
        m_ArcherTLVL2.SetActive(false);
        m_ArcherTLVL3.SetActive(false);
        m_ArcherTLVL4.SetActive(false);
        m_ArcherTLVL5.SetActive(false);

        m_MagicTLVL1.SetActive(false);
        m_MagicTLVL2.SetActive(false);
        m_MagicTLVL3.SetActive(false);
        m_MagicTLVL4.SetActive(false);
        m_MagicTLVL5.SetActive(false);

        m_CannonTLVL1.SetActive(false);
        m_CannonTLVL2.SetActive(false);
        m_CannonTLVL3.SetActive(false);
        m_CannonTLVL4.SetActive(false);
        m_CannonTLVL5.SetActive(false);

        m_FireTLVL1.SetActive(false);
        m_FireTLVL2.SetActive(false);
        m_FireTLVL3.SetActive(false);
        m_FireTLVL4.SetActive(false);
        m_FireTLVL5.SetActive(false);

        m_SlowTLVL1.SetActive(false);
        m_SlowTLVL2.SetActive(false);
        m_SlowTLVL3.SetActive(false);
        m_SlowTLVL4.SetActive(false);
        m_SlowTLVL5.SetActive(false);

        m_MoneyTLVL1.SetActive(false);
        m_MoneyTLVL2.SetActive(false);
        m_MoneyTLVL3.SetActive(false);
        m_MoneyTLVL4.SetActive(false);
        m_MoneyTLVL5.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_TowerSelected == "Ruins")
            {
                m_TowerUIStart.SetActive(true);
                m_TowerUIUpgrade.SetActive(false);
                m_TowerUISell.SetActive(false);
                m_TowerUIStats.SetActive(false);
            }
            else
            {
                if (m_TowerCurrentUpgrade <= 4) { m_TowerUIUpgrade.SetActive(true); }else { m_TowerUIUpgrade.SetActive(false); }
                m_TowerUISell.SetActive(true);
                m_TowerUIStats.SetActive(true);
                m_TowerUIStart.SetActive(false);
            }
        }
    }

    public void Sell()
    {
        m_Moneyfarming = 0;
        m_MoneyFarmingActive = false;
    }

    IEnumerator MoneyFarming()
    {
        while (m_MoneyFarmingActive)
        {
            m_GameManager.m_Coins += m_Moneyfarming;
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_TowerUIStats.SetActive(false);
            m_TowerUIStart.SetActive(false);
            m_TowerUIUpgrade.SetActive(false);
            m_TowerUISell.SetActive(false);
        }
    }
}

    public enum TowerSelect
{
    Ruins,
    ArcherT,
    MagicT,
    CannonT,
    FireT,
    SlowT,
    MoneyT
}
