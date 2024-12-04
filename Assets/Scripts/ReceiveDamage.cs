using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 50;
    public Scrollbar healthBar;
    public GameObject impactParticles;
    private int currentHealth;
    private EnemyCounter enemyCounter;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        enemyCounter = FindObjectOfType<EnemyCounter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(damage);
            if (impactParticles != null)
            {
                Instantiate(impactParticles, collision.contacts[0].point, Quaternion.identity);
            }

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            LoseCondition loseCondition = FindObjectOfType<LoseCondition>();
            if (loseCondition != null)
            {
                loseCondition.Lose();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            if (enemyCounter != null)
            {
                enemyCounter.EnemyDefeated(gameObject);
            }
            Destroy(gameObject);
        }
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.size = (float)currentHealth / maxHealth;
        }
    }

    private void OnDestroy()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddPoint();
        }
    }
}
