using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Tower Type")]
    public TowerSelect TowerType = new TowerSelect();

    [Header("Tower Stats")]
    public int m_TowerDamage;
    public float m_TowerRange;
    public float m_TowerFireRate;
    public int m_TowerCost;
    public int m_Moneyfarming;

    void Start()
    {
        //select tower type
        if (TowerType == TowerSelect.ArcherT)
        {
            m_TowerDamage = 0;
            m_TowerRange = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;
        }
        else if (TowerType == TowerSelect.MagicT)
        {
            m_TowerDamage = 0;
            m_TowerRange = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;
        }
        else if (TowerType == TowerSelect.CannonT)
        {
            m_TowerDamage = 0;
            m_TowerRange = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;
        }
        else if (TowerType == TowerSelect.FireT)
        {
            m_TowerDamage = 0;
            m_TowerRange = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;

        }
        else if (TowerType == TowerSelect.SlowT)
        {
            m_TowerDamage = 0;
            m_TowerRange = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;
        }
        else if (TowerType == TowerSelect.MoneyT)
        {
            m_Moneyfarming = 0;
            m_TowerFireRate = 0;
            m_TowerCost = 0;
        }

    }
}

    public enum TowerSelect
{
    ArcherT,
    MagicT,
    CannonT,
    FireT,
    SlowT,
    MoneyT
}
