using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPoolTank : MonoBehaviour
{
    // Variables

    [SerializeField] private GameObject acidPool;

    // Handling collision with the enemies
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            GameJuiceEffects();
            Instantiate(acidPool,new Vector3(transform.position.x , 0.5f , transform.position.z),Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Game juice effects for when the enemy collides with acid tank
    private void GameJuiceEffects(){
        
    }
}
