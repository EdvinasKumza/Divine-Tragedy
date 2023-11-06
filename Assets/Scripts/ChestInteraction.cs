using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public Animator chestAnimator;
    private bool isPlayerNear = false;

    private void Update()
    {
        // Check if the player is near the chest and has pressed the 'E' key
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
            // Debug.Log("E Key pressed when near the chest");
        }
        if (chestAnimator.GetCurrentAnimatorStateInfo(0).IsName("OpenChest") &&
       chestAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            // Debug.Log("Player is near the chest");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void OpenChest()
    {
        // Trigger the chest opening animation
        chestAnimator.SetTrigger("OpenChest");
        // Disable the collider so it can't be opened again
        GetComponent<Collider2D>().enabled = false;
    }
}