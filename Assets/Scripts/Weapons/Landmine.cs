using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landmine : MonoBehaviour
{

    // Variables

    [SerializeField] private float explosionRadius;
    [SerializeField] private ParticleSystem blastEffect;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            Explode();
        }
    }
    private void Explode(){
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach(Collider collider in enemiesInRange){
            if(collider.gameObject.CompareTag("Enemy")){
                collider.gameObject.GetComponent<EnemyCollisionsHandler>().Die();
            }
        }

        BlastEffects();
        Destroy(gameObject);
    }

    private void BlastEffects(){
        Instantiate(blastEffect,transform.position,Quaternion.identity);
    }    
}
