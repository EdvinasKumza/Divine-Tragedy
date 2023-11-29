using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IDataPersistence
{
    [SerializeField] public float health;
    [SerializeField] public int currentXP;
    [SerializeField] public int maxLevelXP;

    private bool shieldUnlocked = false;
    public static event Action OnPlayerDeath;
    public HealthBarScript healthBar;
    public XPBarScript xpBar;
    public GoldCounter goldCounter;
    public int currentLevel = 1;

    public int gold;
    private bool isShieldActive = false;
    private bool shieldOnCooldown = false;
    private float shieldCooldown = 60f;
    private float shieldDuration = 3f;
    
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
        if(Input.GetKeyDown(KeyCode.F) && !shieldOnCooldown && shieldUnlocked)
        {
            ActivateShield();
        }
    }

    public void LoadData(GameData data)
    {
        this.gold = data.gold;
        goldCounter.SetGoldAmount(gold);
        
        if (data.maxHPUpgradeUnlocked)
        {
            Debug.Log("Max HP Upgrade is unlocked. Increasing Max HP.");
            IncreaseMaxHp();
        }
        if(data.shieldUnlocked)
        {
            shieldUnlocked = true;
        }
    }
    
    public void SaveData(ref GameData data)
    {
        data.gold = this.gold;
    }

    public void TakeDamage(float damage)
    {
        if(!isShieldActive)
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

    public void KillEnemy(int xp)
    {
        IncreaseGold();
        
        currentXP += xp;

        if (currentXP >= maxLevelXP)
        {
            ++currentLevel;
            currentXP -= maxLevelXP;
        }
        
        xpBar.SetXP(currentXP);
    }

    public void IncreaseGold()
    {
        gold += 1;
        goldCounter.SetGoldAmount(gold);
    }

    public void IncreaseMaxHp()
    {
        health *= 2;
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        StartCoroutine(ShieldDuration());
        StartCoroutine(ShieldCooldown());
    }
    
    public IEnumerator ShieldDuration()
    {
        yield return new WaitForSeconds(shieldDuration);
        isShieldActive = false;
    }

    public IEnumerator ShieldCooldown()
    {
        shieldOnCooldown = true;
        yield return new WaitForSeconds(shieldCooldown);
        shieldOnCooldown = false;
    }
}
