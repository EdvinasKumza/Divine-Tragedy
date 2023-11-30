using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dummyEnemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!dummyEnemy.IsDestroyed())
        {
            dummyEnemy.SetActive(true);
        }
    }
}
