using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    // Variables

    [SerializeField] private float deadzoneRadius;
    [SerializeField] private float timeDuration;
    private void Start() {
        
        DestroyEnemies();
        GasEffects();
        Invoke("SelfDestruct", timeDuration);
        
    }

    // Kill the enemies in the region
    private void DestroyEnemies(){
        foreach(Collider col in Physics.OverlapSphere(transform.position, deadzoneRadius)){
            if(col.gameObject.CompareTag("Enemy")){
                KillEffects();
                Destroy(col.gameObject);
            }
        }
    }

    // Game juice effects when the gas kills the enemies
    private void KillEffects(){
        
    }

    // Manages the visuals of the gas and the game juice effects for the gas look
    private void GasEffects(){
        
    }

    // Self Destruct
    private void SelfDestruct(){
        Destroy(gameObject);
    }
}
