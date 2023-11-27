using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounter : MonoBehaviour
{
    private TMP_Text text;

    public void Start()
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
        text.text = "0";
    }

    public void SetGoldAmount(int gold)
    {
        text.text = gold.ToString();
    }
}
