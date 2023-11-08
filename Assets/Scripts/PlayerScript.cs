using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float health;

    public static event Action OnPlayerDeath;
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
            health = 0;
            Debug.Log("Player die");
            OnPlayerDeath?.Invoke();
        }
    }
}
