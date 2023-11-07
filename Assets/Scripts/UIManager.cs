using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    public GameObject gameOverMenu;

    //subscribe to event
    private void OnEnable()
    {
        PlayerScript.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        PlayerScript.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
