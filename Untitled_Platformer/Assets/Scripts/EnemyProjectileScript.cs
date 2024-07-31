using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float speed = 10f;
    public float lifespan = 5f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        // var vel = GetComponent<Rigidbody2D>().velocity;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.transform.rotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);
        
        EnemyProjectileScript projectileScript = projectile.GetComponent<EnemyProjectileScript>();
        if (projectileScript != null)
        {
            projectileScript.speed = speed;
            projectileScript.lifespan = lifespan;
        }
    }
}