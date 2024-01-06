using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawnManager : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject crate;
    [SerializeField] int crateSpawnHeight;

    private void Start() {
        SpawnCrate();
    }
    
    // Function that finds a point on the screen to spawn a crate    
    public void SpawnCrate(){

        Vector3 spawnPosition = new Vector3(Random.Range(-10,11),1.1f,Random.Range(-10,11));

        if(Physics.OverlapSphere(spawnPosition,0.05f).Length == 0){

            // Spawning the crate on the spawn point

            Instantiate(crate, new Vector3(spawnPosition.x , crateSpawnHeight , spawnPosition.z), Quaternion.identity);
            GameJuiceEffects();

        }
        else{
            SpawnCrate();
        }

    }

    // Function that adds game juice to the crate spawn 
    private void GameJuiceEffects(){
        // Game Juice
    }
}
