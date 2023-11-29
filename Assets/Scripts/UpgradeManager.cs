using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeManager : MonoBehaviour, IDataPersistence
{
    private GameData gameData;

    public static UpgradeManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData(GameData data)
    {
        gameData = data;
    }

    public void SaveData(ref GameData data)
    {
        data = gameData;
    }

    public bool PurchaseUpgrade(string upgradeName)
    {
        if (upgradeName == "MaxHP" && !gameData.maxHPUpgradeUnlocked && gameData.gold >= 50)
        {
            GoldTree.instance.SpendGold(50);
            gameData.maxHPUpgradeUnlocked = true;
            DataPersistenceManager.instance.SaveGame();
            
            return true;
        }
        else if (upgradeName == "FireRate" && !gameData.fireRateUnlocked && gameData.maxHPUpgradeUnlocked && gameData.gold >= 100)
        {
            GoldTree.instance.SpendGold(100);
            gameData.fireRateUnlocked = true;
            DataPersistenceManager.instance.SaveGame();
            
            return true;
        }
         else if (upgradeName == "Shield" && !gameData.shieldUnlocked && gameData.maxHPUpgradeUnlocked && gameData.gold >= 100)
        {
            GoldTree.instance.SpendGold(100);
            gameData.shieldUnlocked = true;
            DataPersistenceManager.instance.SaveGame();
            
            return true;
        }
        return false;
    }

    public bool IsUpgradePermanentlyUnlocked(string upgradeName)
    {
        if (gameData != null)
        {
            if (upgradeName == "MaxHP")
            {
                return gameData.maxHPUpgradeUnlocked;
            }
            if(upgradeName == "FireRate")
            {
                return gameData.fireRateUnlocked;
            }
            if(upgradeName == "Shield")
            {
                return gameData.shieldUnlocked;
            }
        }

        return false;
    }
}
