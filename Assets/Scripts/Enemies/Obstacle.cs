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
            other.gameObject.transform.GetComponent<PlayerHurtEffect>().PlayerHurt();
            GameData.health--;
            Destroy(gameObject);
        }
    }

    private void SelfDestruct(){
        Destroy(gameObject);
    }

}
