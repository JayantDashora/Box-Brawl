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
                AttackEffect();
                Destroy(other.gameObject);
            }
            else{
                DestroyEffect();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        // Reduces player health on collision with him and destroys itself

        if(other.gameObject.CompareTag("Player")){
            
            // Updating health
            GameData.health--;
            // Game Juice Effects for harming the player
            PlayerHurtEffects(); 
            // Destroying the enemy
            Destroy(gameObject);

        }
    }

    // Effect played when the acid pool's health is over.
    private void DestroyEffect(){
        
    }

    // Acid kill effect (When the enemy collides with the acid pool) ( Game Juice Effect)
    private void AttackEffect(){

    }

    // Game Juice effects for harming the player
    private void PlayerHurtEffects(){
        
    }
    
}
