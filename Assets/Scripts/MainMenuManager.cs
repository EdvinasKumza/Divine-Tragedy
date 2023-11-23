using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadUpgradeMenu()
    {
        //TODO
    }

    public void LoadSettingsMenu()
    {
        //TODO
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
