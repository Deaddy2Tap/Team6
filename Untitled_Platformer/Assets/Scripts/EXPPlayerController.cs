using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPPlayerController : MonoBehaviour
{
    int jumpsAmount = 2;
    bool canJump = false;
    bool canDash = true;
    bool isDashing = false;
    int dashCountdown;
    Vector2 dashDirection;
    float initialDashY;
    Rigidbody2D rb;
    [SerializeField] int dashDuration = 30;
    [SerializeField] float dashForce = 20f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float moveForce = 10f;
    [SerializeField] float extraGravity = 5f;  // Extra gravity to reduce floatiness

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(0, 0);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            canDash = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsAmount--;
            if (jumpsAmount < 1)
            {
                canJump = false;
            }
            // Play the jump sound
            AudioManager.instance.PlayJumpSound();
        }

        if (canDash && !isDashing && Input.GetKey(KeyCode.LeftShift))
        {
            isDashing = true;
            dashCountdown = dashDuration;
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;
            initialDashY = transform.position.y;
            rb.velocity = new Vector2(dashDirection.x * dashForce, 0);  // Set initial dash velocity
        }

        if (Input.GetKey(KeyCode.A))
        {
            v.x -= moveForce;
        }

        if (Input.GetKey(KeyCode.D))
        {
            v.x += moveForce;
        }

        rb.velocity = new Vector2(v.x, rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            // Maintain the player's vertical position and set horizontal velocity
            rb.velocity = new Vector2(dashDirection.x * dashForce, 0);
            transform.position = new Vector2(transform.position.x, initialDashY);
            dashCountdown--;
            if (dashCountdown <= 0)
            {
                isDashing = false;
                canDash = false;
            }
        }

        // Apply extra gravity to reduce floatiness
        if (rb.velocity.y < 0 || !Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.down * extraGravity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Jumpable")
        {
            canDash = false;
            canJump = true;
            jumpsAmount = 2;
        }
    }
}
