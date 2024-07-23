using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float detectionRange = 40.0f;
    [SerializeField] private LayerMask obstacleMask;

    private bool targetInSight = false;

    void Start()
    {
        GameObject targetObject = GameObject.FindWithTag("Player");
        if (targetObject != null)
        {
            target = targetObject.transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 directionToTarget = target.position - transform.position;
            transform.up = directionToTarget;

            targetInSight = IsTargetInSight();
        }
    }

    bool IsTargetInSight()
    {
        Vector2 directionToTarget = target.position - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        if (distanceToTarget <= detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask);

            // Draw a ray to visualize the detection
            if (hit.collider == null)
            {
                Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.red);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, directionToTarget.normalized * distanceToTarget, Color.green);
                return false;
            }
        }
        return false;
    }
}