using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private GameObject gun;

    private void OnTriggerEnter2D(Collider2D other)
        {
            gun.SetActive(true);
        }
}
