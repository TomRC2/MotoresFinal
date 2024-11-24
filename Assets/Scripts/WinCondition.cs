using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject WinPanel;
    public GameObject HudShooter;

    void Start()
    {
        Time.timeScale = 1f;
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    public void EnemyDefeated(GameObject enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
            CheckForWin();
        }
    }

    private void CheckForWin()
    {
        if (enemies.Count == 0)
        {
            WinPanel.SetActive(true);
            HudShooter.SetActive(false);
            ShowCursor();
        }
    }
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}