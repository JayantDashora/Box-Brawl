using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    // Handling collisions with the enemies
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            EnemyExitEffect();
            GameData.health--;
            Destroy(other.gameObject);
        }
    }

    // Game juice effects for when the enemy leaves the level
    private void EnemyExitEffect(){
        GameObject.FindWithTag("Player").GetComponent<PlayerHurtEffect>().PlayerHurt();
    }
}
