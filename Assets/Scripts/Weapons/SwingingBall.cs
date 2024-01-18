using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingBall : MonoBehaviour
{
    // Variables

    [SerializeField] private float degreesPerSecond;
    [SerializeField] private float radius;
    [SerializeField] private float movementSpeed;
    private GameObject playerRef;
    private void Start() {

        if(GameObject.FindGameObjectsWithTag("SwingingBall").Length > 1 && GameObject.FindGameObjectsWithTag("SwingingBall")[0] != this.gameObject){
            Destroy(gameObject);
        }

        // Player Reference
        playerRef = GameObject.FindWithTag("Player");

        // Set position to the right point and making the player the parent object
        transform.position = new Vector3(transform.position.x + radius, 1, transform.position.z);
        
        
    }

    private void FixedUpdate() {
        
        // Revolve around the player
        RevolveAroundPlayer();

    }

    // Revolve around the player
    private void RevolveAroundPlayer(){

        if(Vector3.Distance(transform.position, playerRef.transform.position) > radius){
            // To stop the ball from moving out of reach
            transform.position = Vector3.Lerp(transform.position, playerRef.transform.position,movementSpeed * Time.deltaTime);
        }
        else{
            transform.RotateAround(playerRef.transform.position,Vector3.up,degreesPerSecond*Time.deltaTime);
        }    
    
    }

    // Managing collisions with other objects

    private void OnCollisionEnter(Collision other) {

        // Destroying enemies on collision 

        if(other.gameObject.CompareTag("Enemy")){

            // Game juice effect when the enemy is killed

           
            other.gameObject.GetComponent<EnemyCollisionsHandler>().Die();;
            
        }

    }

}
