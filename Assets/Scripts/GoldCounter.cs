using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GoldCounter : MonoBehaviour
{
    private TMP_Text text;

    public void Start()
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
    }

    public void SetGoldAmount(int gold)
    {
        if (text.IsUnityNull())
        {
            text = gameObject.GetComponentInChildren<TMP_Text>();
        }
        text.text = gold.ToString();
    }
}
