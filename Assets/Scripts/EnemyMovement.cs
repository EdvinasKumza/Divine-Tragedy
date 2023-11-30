using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float StopDistance;
    [SerializeField] private float ReturnDistance;

    public bool Flee = false;
    public AudioClip enemyHitSound; // Add this field to assign the enemy hit sound
    public SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource is not found, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        float previousPosition = transform.position.x;

        if (distance <= StopDistance) return;
 

        if (!Flee)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (distance > ReturnDistance) Flee = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);
        }

        if (transform.position.x > previousPosition)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerScript player = col.gameObject.GetComponent<PlayerScript>();

            if (player != null)
            {
                player.TakeDamage(this.gameObject.GetComponent<Enemy>().damage);

                // Play enemy hit sound
                if (audioSource != null && enemyHitSound != null)
                {
                    audioSource.PlayOneShot(enemyHitSound);
                }
            }

            Flee = true;
        }
    }
}
