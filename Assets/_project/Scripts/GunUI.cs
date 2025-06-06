using UnityEngine;

public class GunUI : MonoBehaviour
{
    [SerializeField] private PlayerScript m_PlayerScript;
    [SerializeField] private GameObject m_GunSelected;
    [SerializeField] private GameObject m_HandSelected;

    void Update()
    {
        Selected();
    }

    public void Selected()
    {
        //switches between gun and hand UI when pressing 1 or 2 on keyboard
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_GunSelected.SetActive(false);
            m_HandSelected.SetActive(true);
            m_PlayerScript.m_IsGunSelected = false;
            m_PlayerScript.m_IsHandSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_GunSelected.SetActive(true);
            m_HandSelected.SetActive(false);
            m_PlayerScript.m_IsHandSelected = false;
            m_PlayerScript.m_IsGunSelected = true;
        }

    }
}
