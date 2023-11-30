using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private GameObject beginningScreen;
    [SerializeField] private GameObject xpScreen;
    [SerializeField] private GameObject goldScreen;
    [SerializeField] private GameObject levelUPScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject dummyEnemy;
    [SerializeField] private GameObject dummyEnemy2;
    [SerializeField] private GameObject dummyEnemy3;

    private bool beginning = true;
    private bool killEnamyXp = false;
    private bool killEnamyGold = false;
    private bool levelUP = false;

    private bool enemy2 = false;
    private bool enemy3 = false;

    private bool complete;

    private void OnEnable()
    {
        EnemyTutorial.OnEnemyDeath += KillEnemy;
    }

    private void OnDisable()
    {
        EnemyTutorial.OnEnemyDeath -= KillEnemy;
    }
    
    public void LoadData(GameData data)
    {
        complete = data.levelUnlock[1];
    }
    
    public void SaveData(ref GameData data)
    {
        if (complete)
        {
            data.levelUnlock[1] = true;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        gun.GetComponent<Shooting>().SetStartingWeapon("bow");
        beginningScreen.SetActive(beginning);
        xpScreen.SetActive(false);
        goldScreen.SetActive(false);
        levelUPScreen.SetActive(false);
        victoryScreen.SetActive(false);
        Time.timeScale = 0;
        gun.SetActive(false);
        dummyEnemy.SetActive(false);
        dummyEnemy2.SetActive(false);
        dummyEnemy3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (beginning)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                beginningScreen.SetActive(false);
                beginning = false;
                Time.timeScale = 1;
            }
        }else if (killEnamyXp)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                killEnamyXp = false;
                xpScreen.SetActive(false);
                goldScreen.SetActive(true);
                killEnamyGold = true;
            }
        }else if (killEnamyGold)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                goldScreen.SetActive(false);
                killEnamyGold = false;
                Time.timeScale = 1;
            }
        }else if (levelUP)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                levelUPScreen.SetActive(false);
                levelUP = false;
                Time.timeScale = 1;
            }
        }
    }
    
    public void KillEnemy(int xp)
    {
        if (enemy2)
        {
            levelUPScreen.SetActive(true);
            Time.timeScale = 0;
            levelUP = true;
            enemy2 = false;
            enemy3 = true;
        }
        else if (enemy3)
        {
            victoryScreen.SetActive(true);
            Time.timeScale = 0;
            complete = true;
            DataPersistenceManager.instance.SaveGame();
        }
        else
        {
            xpScreen.SetActive(true);
            killEnamyXp = true;
            Time.timeScale = 0;
            enemy2 = true;
        }
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
