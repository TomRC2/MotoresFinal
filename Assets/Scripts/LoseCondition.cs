using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public GameObject HudShooter;
    public GameObject LosePanel;
    public void Lose() 
    { 
        LosePanel.SetActive(true);
        HudShooter.SetActive(false);
        Time.timeScale = 0f;
        ShowCursor();
    }

    public void VolverAJugar()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
