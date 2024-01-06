using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionsHandler : MonoBehaviour
{

    // Handling collisions
    private void OnCollisionEnter(Collision other) {
        
        // Handling collisons with the player

        if(other.gameObject.CompareTag("Player")){
            
            // Updating health
            GameData.health--;
            // Game Juice Effects for harming the player
            GameJuiceEffects(); 
            // Destroying the enemy
            Destroy(gameObject);

        }

    }
    private void GameJuiceEffects(){
        // Game Juice
    }

}
