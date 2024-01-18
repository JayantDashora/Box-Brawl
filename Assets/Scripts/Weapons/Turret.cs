using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    // Variables
    [SerializeField] private float shootingFrequency;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float duration;
    [SerializeField] private float attackRadius;
    [SerializeField] private ParticleSystem shootEffect;
    private Transform targetEnemy;
    private bool canRotate = false;

    private void Start() {
        // Timer for how long the turret will be there
        Invoke("SelfDestruct",duration);

        // Shooting with the specified frequency
        InvokeRepeating("Shoot", 0.1f, shootingFrequency);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            canRotate = true;
        }
    }

    private void Shoot(){

        // Find the target

        targetEnemy = FindClosestEnemy(Physics.OverlapSphere(transform.position, attackRadius)).transform;
        
        // Rotate towards it
        if(canRotate){
            Vector3 direction = (targetEnemy.position - transform.position).normalized;
            transform.forward = direction;
        }

        
        // Shoot at it
        ShootEffects();
        if(canRotate)
            Instantiate(bullet,shootPoint.position,transform.rotation);

    }

    // Game juice effects for shooting
    private void ShootEffects(){
        Instantiate(shootEffect,shootPoint.position,Quaternion.identity);
    }



    private void SelfDestruct(){
        Destroy(gameObject);
    }

    // Finding closest enemy 

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
}
