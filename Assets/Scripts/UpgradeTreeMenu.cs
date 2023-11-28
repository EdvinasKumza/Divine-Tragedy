using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeTreeMenu : MonoBehaviour, IDataPersistence
{   
    private List<UpgradeTree> upgrades;
    private GameData gameData;
    public void LoadData(GameData data)
    {
        this.gameData = data;
    }
    
    public void SaveData(ref GameData data)
    {
        
    }
    public void Start()
    {

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
