using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip groundMoveSound;

    public Animator animator;

    private Rigidbody2D body;
    private bool grounded;
    private AudioSource audioSource;

    private bool isMoving; // Flag to check if the character is moving horizontally
    private bool isJumping; // Flag to check if the character is currently in the jump animation

    // Subscribe to event
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
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        EnablePlayerMovement();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        FlipCharacter(horizontalInput);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        isMoving = Mathf.Abs(horizontalInput) > 0.1f;

        if (grounded && isMoving && !audioSource.isPlaying)
        {
            audioSource.clip = groundMoveSound;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            grounded = false;

            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }

            // Set the "IsJumping" parameter to true when jumping
            isJumping = true;
            animator.SetBool("IsJumping", isJumping);
        }

        // Check if the character is still in the air to reset the "IsJumping" parameter
        if (!grounded)
        {
            animator.SetBool("IsJumping", true);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }

    private void FlipCharacter(float horizontalInput)
    {
        // Flip the character based on the movement direction
        if (horizontalInput > 0.1f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f); // Facing left
        }
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
            // Set the "IsJumping" parameter to false when landing on the ground
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
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
