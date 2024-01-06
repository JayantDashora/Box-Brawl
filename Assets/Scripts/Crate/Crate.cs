using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    // Variables

    CrateSpawnManager crateSpawnManagerRef;
    GameObject playerRef;
    [SerializeField] private GameObject[] weapons;

    private void Start() {
        crateSpawnManagerRef = GameObject.Find("GameManagers/CrateSpawnManager").GetComponent<CrateSpawnManager>();
        playerRef = GameObject.FindWithTag("Player");
    }

    // If an enemy pushes the crate out of the arena
    private void Update() {
        if(transform.position.y < -1){
            Destroy(gameObject);
            crateSpawnManagerRef.SpawnCrate();
        }
    }

    // Checking collisions with other objects

    private void OnCollisionEnter(Collision other) {
        
        // Checking collision with player
        
        if(other.gameObject.CompareTag("Player"))
        {

            // Spawn new crates
            crateSpawnManagerRef.SpawnCrate();

            // Removing weapons which are already present and preparing for the new ones
            PreviousWeaponsCleanup();

            // Giving new weapons
            Instantiate(weapons[Random.Range(0, weapons.Length)], playerRef.transform.position, Quaternion.identity, playerRef.transform.GetChild(0));

            // Adding to the game score
            GameData.score++;

            // Game Juice
            GameJuiceEffects();

            // Destroy itself
            Destroy(gameObject);

        }


    }

    private void PreviousWeaponsCleanup()
    {
        // Destroying other weapons before that

        if (playerRef.transform.GetChild(0).transform.childCount > 0)
        {
            for (int i = 0; i < playerRef.transform.GetChild(0).transform.childCount; i++)
            {
                Destroy(playerRef.transform.GetChild(0).GetChild(i).gameObject);
            }
        }

        // Destroy swingingball if there 

        if (GameObject.FindWithTag("SwingingBall") != null)
        {
            Destroy(GameObject.FindWithTag("SwingingBall"));
        }
    }

    // Function that adds game juice to the crate pickup 
    private void GameJuiceEffects(){
        // Game Juice
    }

}
