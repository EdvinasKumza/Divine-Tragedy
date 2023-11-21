using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public int currentXP;
    [SerializeField] public int maxLevelXP;

    public static event Action OnPlayerDeath;
    public HealthBarScript healthBar;
    public XPBarScript xpBar;
    public int currentLevel = 1;
    
    //subscribe to event
    private void OnEnable()
    {
        Enemy.OnEnemyDeath += IncreaseXP;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= IncreaseXP;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(health);
        xpBar.SetMaxXP(maxLevelXP);
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

    public void IncreaseXP(int xp)
    {
        currentXP += xp;

        if (currentXP >= maxLevelXP)
        {
            ++currentLevel;
            currentXP -= maxLevelXP;
        }
        
        xpBar.SetXP(currentXP);
    }
}
