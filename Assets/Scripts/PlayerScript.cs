using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] public float health;
    [SerializeField] public int currentXP;
    [SerializeField] public int maxLevelXP;

    public static event Action OnPlayerDeath;
    public HealthBarScript healthBar;
    public XPBarScript xpBar;
    public int currentLevel = 1;

    public int gold;

    public UIManeger UI;
    
    //subscribe to event
    private void OnEnable()
    {
        Enemy.OnEnemyDeath += KillEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= KillEnemy;
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

    public void LoadData(GameData data)
    {
        this.gold = data.gold;
    }
    
    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
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

    public void KillEnemy(int xp)
    {
        IncreaseGold();
        
        currentXP += xp;

        if (currentXP >= maxLevelXP)
        {
            ++currentLevel;
            currentXP -= maxLevelXP;
            UI.LevelUp();
        }
        
        xpBar.SetXP(currentXP);
    }

    public void IncreaseGold()
    {
        gold += 1;
    }
}
