using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class aPlayerController : MonoBehaviour
{
    
    public Animator animate;
    int jumpsAmount = 2;
    bool canJump = false;
    bool canDash = true;
    bool isDashing = false;
    int dashCountdown;
    int particleCountdown;
    int startingDashForce = 1;
    Rigidbody2D rb;
    ParticleSystem ps;
    [SerializeField] int particleDuration = 100;
    [SerializeField] int dashDuration = 30;
    [SerializeField] int jumpForce = 20;
    [SerializeField] int moveForce = 10;
    [SerializeField] int dashForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = new Vector2(0, 0);
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            animate.SetBool("isjumping", true);
            canDash = true;
            v.y += jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, v.y);
            jumpsAmount--;
            if (jumpsAmount < 1)
            {
                canJump = false;
            }
        }

        if (canDash && !isDashing && Input.GetKey(KeyCode.LeftShift))
        {
            isDashing = true;
            dashCountdown = dashDuration;
        }

        if (isDashing)
        {
            startingDashForce = dashForce;
            if (--dashCountdown == 0)
            {
                isDashing = false;
                canDash = false;
            }
        }
        else
        {
            startingDashForce = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
           
                  
            v.x -= moveForce * startingDashForce;
            rb.velocity = new Vector2(v.x, rb.velocity.y);
            animate.SetFloat("speed",Mathf.Abs(moveForce));
           
               
        }

        if (Input.GetKey(KeyCode.D))
        {
            v.x += moveForce * startingDashForce;
            rb.velocity = new Vector2(v.x, rb.velocity.y);
            animate.SetFloat("speed", Mathf.Abs(moveForce));
        }

        if (ps.isPlaying)
        {
            if (--particleCountdown == 0)
            {
                ps.Stop();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Jumpable")
        {
            ps.Play();
            particleCountdown = particleDuration;
            canDash = false;
            canJump = true;
            jumpsAmount = 2;
            animate.SetBool("isjumping", false);

        }
    }
    
    }