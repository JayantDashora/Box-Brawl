using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Variables

    [SerializeField] private float duration;

    private void Start() {
        Invoke("SelfDestruct", duration);
    }

    // Handling player collisions

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            PlayerHarmEffect();
            GameData.health--;
            Destroy(gameObject);
        }
    }

    // Game juice effects for when the obstacle collides with the enemy
    private void PlayerHarmEffect(){
        
    }

    private void SelfDestruct(){
        Destroy(gameObject);
    }

}
