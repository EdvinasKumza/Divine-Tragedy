using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject chooseStartingWeapon;
    public GameObject levelUp;
    public static bool isPaused;

    public Shooting weapons;

    //subscribe to event
    private void OnEnable()
    {
        PlayerScript.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        PlayerScript.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void Start()
    {
        pauseMenu.SetActive(false);
        StartWeaponChoice();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void StartWeaponChoice()
    {
        chooseStartingWeapon.SetActive(true);
        Time.timeScale = 0;
    }
    public void StartWeaponBow()
    {
        weapons.SetStartingWeapon("bow");
        chooseStartingWeapon.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartWeaponSword()
    {
        weapons.SetStartingWeapon("sword");
        chooseStartingWeapon.SetActive(false);
        Time.timeScale = 1;
    }

    public void LevelUp()
    {
        levelUp.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelUpClose(string upgrade)
    {
        weapons.Upgrade(upgrade);
        levelUp.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
