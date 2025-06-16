using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool IsGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //player movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveInput, rb.velocity.y);

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            IsGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        // groundcheck 

        if (collision.collider.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}
