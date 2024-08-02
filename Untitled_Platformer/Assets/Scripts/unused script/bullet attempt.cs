using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public Animator animateprojectile;
    public float speed = 20.0f;
    public Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        Destroy(gameObject);
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }

        }
    }
}

