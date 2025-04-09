using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject m_MainMenu;
    public GameObject LevelMenu;
    public GameObject m_Credits;
    public GameObject m_Help;

    private void Start()
    {
        m_MainMenu.SetActive(true);
        LevelMenu.SetActive(false);
        m_Credits.SetActive(false);
        m_Help.SetActive(false);
    }


    void Update()
    {
        
    }
}
