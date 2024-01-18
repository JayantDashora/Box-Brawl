using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionsHandler : MonoBehaviour
{

    // Variables

    public bool isDead = false;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private EnemyCollisionsHandler enemyCollisionsHandler;


    // Handling collisions
    private void OnCollisionEnter(Collision other) {
        
        // Handling collisons with the player

        if((other.gameObject.CompareTag("Player")) && (isDead == false)){
            // Updating health
            GameData.health--;
            Die();
            other.gameObject.transform.GetComponent<PlayerHurtEffect>().PlayerHurt();
        }

    }


    public void Die(){
        // Game Juice Effects for enemy death 
        isDead = true;
        GameJuiceEffects();
        Invoke("SelfDestruct", 3f); 
    }
    private void GameJuiceEffects(){
        
        // Playing death animation for the enemy
        enemyMovement.movementSpeed = 0;
        enemyAnimator.SetTrigger("Death");
        enemyCollisionsHandler.enabled = false;

    }

    private void SelfDestruct(){
        Destroy(gameObject);
    }

}
