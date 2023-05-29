using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndless : MonoBehaviour
{
    EPlayerControls controls;

    public float jumpForce = 5;
    bool isGrounded;
    int numberOfJumps = 0;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;
    //public Animator animator;

    AudioSource audioClip;

    private void Awake()
    {
        audioClip = GetComponent <AudioSource>();
        
        controls = new EPlayerControls();
        controls.Enable();

        controls.Land.Jump.performed += ctx => Jump();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    void Jump()
    {
        if(isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            audioClip.Play();
        }
        else
        {
            if(numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                audioClip.Play();
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
