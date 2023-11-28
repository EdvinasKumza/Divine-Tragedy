using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private GameObject beginningScreen;

    private bool beginning = true;
    
    // Start is called before the first frame update
    void Start()
    {
        beginningScreen.SetActive(beginning);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginning)
        {
            if (Input.anyKey)
            {
                beginningScreen.SetActive(false);
                beginning = false;
                Time.timeScale = 1;
            }
        }
    }
}
