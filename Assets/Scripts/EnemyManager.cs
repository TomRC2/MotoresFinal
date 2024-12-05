using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] wave1Enemies;
    public GameObject[] wave2Enemies;
    public GameObject[] wave3Enemies;

    public GameObject WinPanel;
    public GameObject HudShooter;

    private int defeatedEnemiesCount = 0;
    private int currentWave = 1;

    void Start()
    {
        Time.timeScale = 1f;
        SetWaveActive(wave2Enemies, false);
        SetWaveActive(wave3Enemies, false);
    }

    public void OnEnemyDefeated()
    {
        defeatedEnemiesCount++;

        switch (currentWave)
        {
            case 1:
                if (defeatedEnemiesCount == wave1Enemies.Length)
                {
                    StartNextWave(wave2Enemies, 2);
                }
                break;

            case 2:
                if (defeatedEnemiesCount == wave2Enemies.Length)
                {
                    StartNextWave(wave3Enemies, 3);
                }
                break;

            case 3:
                if (defeatedEnemiesCount == wave3Enemies.Length)
                {
                    
                    Debug.Log("¡Todas las oleadas completadas!");
                    Win();
                }
                break;
        }
    }
    
    void StartNextWave(GameObject[] nextWave, int nextWaveNumber)
    {
        defeatedEnemiesCount = 0;
        currentWave = nextWaveNumber;
        SetWaveActive(nextWave, true);
        Debug.Log($"Oleada {nextWaveNumber} habilitada.");
    }

    void SetWaveActive(GameObject[] wave, bool isActive)
    {
        foreach (GameObject enemy in wave)
        {
            enemy.SetActive(isActive);
        }
    }
    public void Win()
    {
        WinPanel.SetActive(true);
        HudShooter.SetActive(false);
        ShowCursor();
    }
    public void ShowCursor()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
}