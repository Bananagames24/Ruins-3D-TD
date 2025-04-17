using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI m_CoinsText;
    public int m_Coins;
    public TextMeshProUGUI m_WaveText;
    public TextMeshProUGUI m_Lives;
    public int m_LivesCount;
    public GameObject m_WinScreen;

    [SerializeField] private GameObject[] m_Enemies;
    [SerializeField] private Transform m_Spawn;
    public Transform m_EndPoint;

    private int m_WaveCount;
    private bool m_WaveInProgress;

    void Start()
    {
        m_LivesCount = 100;
        m_WaveInProgress = false;
        m_WaveCount = 0;
        m_Coins = 150;
        m_CoinsText.text = "Coins: " + m_Coins;
        m_WinScreen.SetActive(false);
    }

    void Update()
    {
        m_CoinsText.text = "Coins: " + m_Coins;
        m_WaveText.text = "Wave: " + m_WaveCount;
        if (!m_WaveInProgress)
        {
            m_WaveInProgress = true;
            StartCoroutine(SpawnWave());
        }

        if (m_LivesCount <= 0)
        {
            m_Lives.text = "Game Over";
            m_LivesCount = 0;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            m_Lives.text = "Lives: " + m_LivesCount;
        }

        if (m_WaveCount >= 26)
        {
            m_Lives.text = "You Win!";
            m_WinScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }

    IEnumerator SpawnWave()
    {
        switch (m_WaveCount)
        {
            case 0:
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 1
            case 1:
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(15f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;
            
            //wave 2
            case 2:
                for (int i = 0; i < 6;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 4;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_Coins += 35;
                m_WaveCount++;
                m_WaveInProgress = false;
                break;
            
            //wave 3
            case 3:
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.6f);
                    i++;
                }
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_Coins += 35;
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 4
            case 4:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_Coins += 35;
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 5
            case 5:
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[3], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                for (int i = 0; i < 12;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_Coins += 35;
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 6
            case 6:
                for (int i = 0; i < 7;)
                {
                    Instantiate(m_Enemies[3], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                for (int i = 0; i < 3;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 7
            case 7:
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                for (int i = 0; i < 12;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 8
            case 8:
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(20f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 9
            case 9:
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(5f);
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 10
            case 10:
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 11
            case 11:
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                for (int i = 0; i < 30;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                for (int i = 0; i < 3;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 12
            case 12:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 13
            case 13:
                for (int i = 0; i < 3;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 2;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 14
            case 14:
                for (int i = 0; i < 16;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 15
            case 15:
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.1f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[3], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 16
            case 16:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 17
            case 17:
                for (int i = 0; i < 16;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 14;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 18
            case 18:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 19
            case 19:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 20
            case 20:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[4], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[7], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 21
            case 21:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[3], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 100;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 22
            case 22:
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                
                for (int i = 0; i < 20;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 23
            case 23:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 1;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 24
            case 24:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[6], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[5], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(0.5f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[7], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(3f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(60f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //wave 25
            case 25:
                for (int i = 0; i < 50;)
                {
                    Instantiate(m_Enemies[7], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(1f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(30f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            //End
            case 26:
                yield return new WaitForSecondsRealtime(300f);
                m_WaveCount++;
                break;
        }
    }
}
