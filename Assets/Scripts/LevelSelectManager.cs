using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour, IDataPersistence
{
    public bool[] levelUnlock;

    public GameObject[] levelButtons = new GameObject[10];
    
    public void LoadData(GameData data)
    {
        this.levelUnlock = data.levelUnlock;
    }
    
    public void SaveData(ref GameData data)
    {
        //Nothing to save
    }
    public void Start()
    {
        for (int i = 2; i < 10; ++i)
        {
            if (levelUnlock[i])
            {
                levelButtons[i].transform.Find("Lock").GameObject().SetActive(false);
            }
            else
            {
                levelButtons[i].transform.Find("Lock").GameObject().SetActive(true);
            }
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadTutorial()
    {
        //TODO
    }
    
    public void LoadLevel0()
    {
        SceneManager.LoadScene("Level0");
    }
    
    public void LoadLevel1()
    {
        //TODO
    }
    
    public void LoadLevel2()
    {
        //TODO
    }
}
