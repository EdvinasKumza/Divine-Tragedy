using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D body;
    private bool grounded;

    //subscribe to event
    private void OnEnable()
    {
        PlayerScript.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable()
    {
        PlayerScript.OnPlayerDeath -= DisablePlayerMovement;
    }

    private void Awake()
    {
        //get the rigidbody from the player object
        body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        EnablePlayerMovement();
    }

    private void Update()
    {
        //horizontal movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //jump
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            grounded = false;
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    public void ResetSpeed(float originalSpeed)
    {
        speed = originalSpeed;
    }

    public void ResetJumpSpeed(float originalJumpSpeed)
    {
        jumpSpeed = originalJumpSpeed;
    }
    
    public void ModifySpeed(float speedBoostMultiplier)
    {
        speed *= speedBoostMultiplier;
    }

    public void ModifyJumpSpeed(float jumpSpeedMultiplier)
    {
        jumpSpeed *= jumpSpeedMultiplier;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void DisablePlayerMovement()
    {
        body.bodyType = RigidbodyType2D.Static;
    }
    
    private void EnablePlayerMovement()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
    }
}
