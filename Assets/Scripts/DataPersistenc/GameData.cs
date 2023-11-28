using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    // Witch level have been unlocked 0 - Tutorial, 1 - Level1 ...
    public bool[] levelUnlock = new bool [10];
    
    // new game
    public GameData()
    {
        this.gold = 0;

        // Set level unlock status
        levelUnlock[0] = true;
        levelUnlock[1] = true;
        for (int i = 2; i < 10; ++i)
        {
            levelUnlock[i] = false;
        }
        // new UpgradeTree("IncreaseFireRate", false, 100, new List<string>(), IncreaseFireRate);
        // new UpgradeTree("IncreaseMaxHP", false, 100, new List<string>(), IncreaseMaxHP);
        // new UpgradeTree("Shield", false, 200, new List<string> { "HigherHP" }, ActivateShield);
        // new UpgradeTree("TimeSlow", false, 200, new List<string> { "HigherFireRate" }, ActivateTimeSlow);
    }
}
