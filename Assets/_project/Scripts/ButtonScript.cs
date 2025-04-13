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

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("StartMenus");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HelpGame()
    {
        m_ButtonManager.m_HelpGameUI.SetActive(true);
        m_ButtonManager.m_PauseMenuUI.SetActive(false);
    }
    public void BackGame()
    {
        m_ButtonManager.m_HelpGameUI.SetActive(false);
        m_ButtonManager.m_PauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        m_ButtonManager.m_PauseMenuUI.SetActive(false);
        m_ButtonManager.m_GameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}

