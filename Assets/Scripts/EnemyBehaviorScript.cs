using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100.0f; // Enemy's initial health
    
    [SerializeField] public float damage;

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
        Destroy(gameObject); // Destroy the enemy
    }
}
