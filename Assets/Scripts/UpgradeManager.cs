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
        // Check if the player has enough gold and the MaxHP upgrade is not unlocked
        if (upgradeName == "MaxHP" && !gameData.maxHPUpgradeUnlocked && gameData.gold >= 50)
        {
            gameData.gold -= 50;
            gameData.maxHPUpgradeUnlocked = true;
            
            DataPersistenceManager.instance.SaveGame();
            
            return true;
        }
        return false;
    }
}
