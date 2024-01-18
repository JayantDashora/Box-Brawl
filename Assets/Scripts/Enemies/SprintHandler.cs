using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintHandler : MonoBehaviour
{
    // Variables
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private float attackRadius;
    [SerializeField] private float sprintSpeed;

    private void Update() {
        AttackPlayer();
    }

    // Attack the player if in range 
    private void AttackPlayer(){
        foreach(Collider col in Physics.OverlapSphere(transform.position, attackRadius)){
            if(col.gameObject.CompareTag("Player") && (GetComponent<EnemyCollisionsHandler>().isDead == false)){
                // Attack the player
                SprintEffects();
                enemyMovement.enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, col.gameObject.transform.position, sprintSpeed * Time.deltaTime);
            }
        }
    }

    // Game juice effects when the enemy sprints towards the player
    private void SprintEffects(){
        
    }
}
