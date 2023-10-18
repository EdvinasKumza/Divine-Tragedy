using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D body;
    
    private void Awake()
    {
        //get the rigidbody from the player object
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //horizontal movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //jump
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }
}
