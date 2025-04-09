using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI m_CoinsText;
    public int m_Coins;

    [SerializeField] private GameObject[] m_Enemies;
    [SerializeField] private Transform m_Spawn;
    public Transform m_EndPoint;

    private int m_WaveCount;
    private bool m_WaveInProgress;

    void Start()
    {
        m_WaveInProgress = false;
        m_WaveCount = 0;
        m_Coins = 100;
        m_CoinsText.text = "Coins: " + m_Coins;
    }

    void Update()
    {
        m_CoinsText.text = "Coins: " + m_Coins;
        if (!m_WaveInProgress)
        {
            m_WaveInProgress = true;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        switch (m_WaveCount)
        {
            case 0:
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;
            
            case 1:
                for (int i = 0; i < 6;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 4;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;
            
            case 2:
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[0], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            case 3:
                for (int i = 0; i < 8;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 10;)
                {
                    Instantiate(m_Enemies[1], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;

            case 4:
                for (int i = 0; i < 5;)
                {
                    Instantiate(m_Enemies[3], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                for (int i = 0; i < 12;)
                {
                    Instantiate(m_Enemies[2], m_Spawn.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
                    i++;
                }
                yield return new WaitForSecondsRealtime(10f);
                m_WaveCount++;
                m_WaveInProgress = false;
                break;
        }
    }
}
