using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject[] enemies;
    private void Start() {
        
        // Spawn normal enemies after waiting random number of seconds
        InvokeRepeating("SpawnNormalEnemy",2f,Random.Range(2,4));
        // Spawn obstacle dropper enemies after waiting random number of seconds
        InvokeRepeating("SpawnObstacleDropperEnemy",4f,Random.Range(15,20));
        // Spawn sprinter enemies after waiting random number of seconds
        InvokeRepeating("SpawnSprinterEnemy",6f,Random.Range(15,20));

    }

    // Spawn normal enemy
    private void SpawnNormalEnemy(){

        // Game Juice    
        GameJuiceEffects();
        // Instantiate enemies
        Instantiate(enemies[0], transform.position, Quaternion.identity);

    }

    // Spawn obstacle dropper enemy
    private void SpawnObstacleDropperEnemy(){

        // Game Juice    
        GameJuiceEffects();
        // Instantiate enemies
        Instantiate(enemies[1], transform.position, Quaternion.identity);

    }

    // Spawn sprinter enemy
    private void SpawnSprinterEnemy(){

        // Game Juice    
        GameJuiceEffects();
        // Instantiate enemies
        Instantiate(enemies[2], transform.position, Quaternion.identity);

    }

    // Game juice effect when the enemy spawns
    private void GameJuiceEffects(){
        // Game Juice
    }

}
