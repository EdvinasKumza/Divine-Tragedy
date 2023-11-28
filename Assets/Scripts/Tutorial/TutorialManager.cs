using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject beginningScreen;
    [SerializeField] private GameObject xpScreen;

    private bool beginning = true;
    private bool killEnamy = false;
    
    private void OnEnable()
    {
        EnemyTutorial.OnEnemyDeath += KillEnemy;
    }

    private void OnDisable()
    {
        EnemyTutorial.OnEnemyDeath -= KillEnemy;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        beginningScreen.SetActive(beginning);
        xpScreen.SetActive(false);
        Time.timeScale = 0;
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
        }else if (killEnamy)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                killEnamy = false;
                xpScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    
    public void KillEnemy(int xp)
    {
        xpScreen.SetActive(true);
        killEnamy = true;
        Time.timeScale = 0;
    }
}
