using System;
using System.Collections;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] private float viewRadius = 10f;
    [SerializeField] private float missileSpeed = 5f;

    private void Start() {
        // Spawning at an high altitude
        transform.position = new Vector3(transform.position.x ,5, transform.position.z);
    }

    private void Update()
    {
        // Detect and home towards the nearest enemy
        HomingBehavior();
    }

    private void HomingBehavior()
    {
        // Find all colliders within the view radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewRadius);

        // Find the closest enemy
        GameObject closestEnemy = FindClosestEnemy(colliders);

        // Home towards the closest enemy
        if (closestEnemy != null)
        {
            HomingMove(closestEnemy.transform);
        }
    }

    private GameObject FindClosestEnemy(Collider[] colliders)
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = collider.gameObject;
                }
            }
        }

        return closestEnemy;
    }

    private void HomingMove(Transform target)
    {
        // Calculate direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;

        // Rotate towards the target
        transform.rotation = Quaternion.LookRotation(direction);

        // Move forward
        transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
    }

    // Managing collisions

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Enemy")){
            BlastEffect();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }

    // Blast game juice effect
    private void BlastEffect(){
        
    }
}
