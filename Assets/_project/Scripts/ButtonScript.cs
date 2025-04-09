using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private ButtonManager m_ButtonManager;

    private void Start()
    {
        m_ButtonManager = FindFirstObjectByType<ButtonManager>();
    }

    public void StartGame()
    {
        m_ButtonManager.m_MainMenu.SetActive(false);
        m_ButtonManager.LevelMenu.SetActive(true);
    }

    public void ToMap1()
    {
        SceneManager.LoadScene("Map1");
    }

    public void ToMainBack()
    {
        m_ButtonManager.LevelMenu.SetActive(false);
        m_ButtonManager.m_Credits.SetActive(false);
        m_ButtonManager.m_Help.SetActive(false);
        m_ButtonManager.m_MainMenu.SetActive(true);
    }

    public void Credits()
    {
        m_ButtonManager.m_MainMenu.SetActive(false);
        m_ButtonManager.m_Credits.SetActive(true);
    }

    public void Help()
    {
        m_ButtonManager.m_MainMenu.SetActive(false);
        m_ButtonManager.m_Help.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

