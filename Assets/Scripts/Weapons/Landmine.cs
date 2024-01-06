using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{

    // Variables

    [SerializeField] private float explosionRadius;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            Explode();
        }
    }
    private void Explode(){
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in enemiesInRange){
            if(collider.gameObject.CompareTag("Enemy")){
                Destroy(collider.gameObject);
            }
        }

        BlastEffects();
        Destroy(gameObject);
    }

    private void BlastEffects(){
         // Game juice effects for landmine blast
    }    
}
