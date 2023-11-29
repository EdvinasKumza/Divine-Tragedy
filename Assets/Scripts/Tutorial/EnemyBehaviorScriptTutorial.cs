using UnityEngine;
using System;

public class EnemyTutorial : MonoBehaviour
{
    public float health = 100.0f; // Enemy's initial health
    public static event Action<int> OnEnemyDeath;
    
    [SerializeField] public float damage;
    [SerializeField] public int xp;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die(); // Implement death logic if health reaches zero
        }
    }

    void Die()
    {
        // Handle enemy's death, e.g., play death animation, spawn items, etc.
        OnEnemyDeath?.Invoke(xp);
        Destroy(gameObject); // Destroy the enemy
    }
}
