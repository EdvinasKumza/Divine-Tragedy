using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KillCube : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("3");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
            Debug.Log("1");
            if (player != null)
            {
                Debug.Log("2");
                player.TakeDamage(500f);
            }
        }
    }
}
