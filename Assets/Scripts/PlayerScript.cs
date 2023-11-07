using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float health;

    public HealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die(); // Implement death logic if health reaches zero
        }
    }
    
    private void Die()
    {
        Debug.Log("Player die");
        // Handle enemy's death, e.g., play death animation, spawn items, etc.
        //TODO
    }
}
