using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{   
    public void LoadLevelSelect()
    {
        //TODO
        SceneManager.LoadScene("Level0");
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
