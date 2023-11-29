using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TooltipDisplay : MonoBehaviour
{
    public static TooltipDisplay _instance;
    public TextMeshProUGUI TextComponent;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position = Input.mousePosition;
        Vector3 offset = new Vector3(50, -50); // Adjust this offset as needed
        transform.position = Input.mousePosition + offset;
    }

    public void SetAndShowToolTip(string message)
    {
        gameObject.SetActive(true);
        TextComponent.text = message;
    }

    public void SetAndHideToolTip()
    {
        gameObject.SetActive(false);
        TextComponent.text = "";
    }
}
