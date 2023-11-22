using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBarScript : MonoBehaviour
{

    public Slider slider;
    private TMP_Text text;

    public void Start()
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
        text.text = "0";
    }

    public void SetMaxXP(int xp)
    {
        slider.maxValue = xp;
        slider.value = 0;
    }
    
    public void SetXP(int xp)
    {
        slider.value = xp;
        text.text = xp.ToString();
    }
}
