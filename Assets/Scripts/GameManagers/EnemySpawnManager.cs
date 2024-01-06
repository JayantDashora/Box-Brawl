using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject[] enemies;
    private void Start() {
        
        // Spawn enemies at the start
        SpawnEnemy();
        // Spawn enemies after waiting random number of seconds
        InvokeRepeating("SpawnEnemy",2f,Random.Range(2,4));

    }

    private void SpawnEnemy(){

        // Game Juice    
        GameJuiceEffects();
        // Instantiate enemies
        Instantiate(enemies[Random.Range(0,enemies.Length)], transform.position, Quaternion.identity);

    }
    private void GameJuiceEffects(){
        // Game Juice
    }

}
