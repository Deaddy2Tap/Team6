using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float detectionRange = 40.0f;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private Transform firePoint; // The fire point from where the enemy will shoot
    [SerializeField] private GameObject projectilePrefab; // The projectile prefab
    [SerializeField] private float fireRate = 1.0f; // The rate at which the enemy shoots
    [SerializeField] private float lockOnTime = 2.0f; // Time required to lock onto the player

    private bool targetInSight = false;
    private float nextFireTime = 0f;
    private float lockOnTimer = 0f; // Timer to track how long the target has been in sight

    void Start()
    {
        GameObject targetObject = GameObject.FindWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }

        if (target == null)
        {
            Debug.LogError("Player target not found");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 directionToTarget = target.position - transform.position;
            transform.up = directionToTarget;

            targetInSight = IsTargetInSight();
            Debug.Log("Target In Sight: " + targetInSight);

            if (targetInSight)
            {
                lockOnTimer += Time.deltaTime;
                Debug.Log("Lock-On Timer: " + lockOnTimer);
            }
            else
            {
                lockOnTimer = 0f; // Reset the timer if the target goes out of sight
                Debug.Log("Lock-On Timer reset");
            }

            if (lockOnTimer >= lockOnTime && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    bool IsTargetInSight()
    {
        Vector2 directionToTarget = target.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget <= detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask);

            if (hit.collider == null)
            {
                Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.red);
                Debug.Log("No obstacle detected, target in sight. Direction: " + directionToTarget + ", Distance: " + distanceToTarget);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
                Debug.Log("Obstacle detected, target not in sight. Hit: " + hit.collider.name + ", Direction: " + directionToTarget + ", Distance: " + distanceToTarget);
                return false;
            }
        }
        Debug.Log("Target out of detection range. Distance: " + distanceToTarget);
        return false;
    }

    void Shoot()
    {
        Debug.Log("Shooting at target");
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}