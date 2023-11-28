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
            gameData.maxHPUpgradeUnlocked = true;
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
        }

        return false;
    }
}
