using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    int jumpsAmount = 2;
    bool canJump;
    Rigidbody2D rb;
    [SerializeField] int jumpForce = 20;
    [SerializeField] int moveForce = 10;
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
            v.y += jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, v.y);
            jumpsAmount--;
            if(jumpsAmount < 1)
            {
                canJump = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            v.x -= moveForce;
            rb.velocity = new Vector2(v.x, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            v.x += moveForce;
            rb.velocity = new Vector2(v.x, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Jumpable")
        {
            canJump = true;
            jumpsAmount = 2;
        }
    }
}
