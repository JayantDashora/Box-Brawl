using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour
{
    // Variables

    [SerializeField] private int health;

    // Handling Collisions
    private void OnCollisionEnter(Collision other) {

        // Kills enemy on collision and reduces the health

        if(other.gameObject.CompareTag("Enemy")){

            if(health > 0){
                health--;
                
                other.gameObject.GetComponent<EnemyCollisionsHandler>().Die();
            }
            else{
                
                other.gameObject.GetComponent<EnemyCollisionsHandler>().Die();
                Destroy(gameObject);
            }
        }

        // Reduces player health on collision with him and destroys itself

        if(other.gameObject.CompareTag("Player")){
            
            // Updating health
            GameData.health--;
            other.gameObject.transform.GetComponent<PlayerHurtEffect>().PlayerHurt();
            // Destroying the enemy
            Destroy(gameObject);

        }
    }


    
}
