using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovementTutorial : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float speed;

    [SerializeField] private float StopDistance;

    [SerializeField] private float ReturnDistance;

    public bool Flee = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        
        if(distance <= StopDistance) return;

        if (!Flee)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (distance > ReturnDistance) Flee = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerScript player = col.gameObject.GetComponent<PlayerScript>();
            
            if (player != null)
            {
                player.TakeDamage(this.gameObject.GetComponent<EnemyTutorial>().damage);
            }
            
            Flee = true;
        }
    }
}
