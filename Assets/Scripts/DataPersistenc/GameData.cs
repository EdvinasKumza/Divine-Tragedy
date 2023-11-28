using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    // Witch level have been unlocked 0 - Tutorial, 1 - Level1 ...
    public bool[] levelUnlock = new bool [10];
    public bool maxHPUpgradeUnlocked = false;
    
    // new game
    public GameData()
    {
        this.gold = 0;
        this.maxHPUpgradeUnlocked = false;

        // Set level unlock status
        levelUnlock[0] = true;
        levelUnlock[1] = true;
        for (int i = 2; i < 10; ++i)
        {
            levelUnlock[i] = false;
        }
    }
}
