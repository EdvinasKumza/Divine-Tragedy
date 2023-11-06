using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

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
