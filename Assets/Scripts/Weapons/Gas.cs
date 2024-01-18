using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    // Variables

    [SerializeField] private float deadzoneRadius;
    [SerializeField] private float timeDuration;
    [SerializeField] private float attackTime;
    private void Start() {
        
        transform.position = GameObject.FindWithTag("Player").transform.position;
        Invoke("DestroyEnemies", attackTime);
        Invoke("SelfDestruct", timeDuration);
        
    }

    // Kill the enemies in the region
    private void DestroyEnemies(){
        foreach(Collider col in Physics.OverlapSphere(transform.position, deadzoneRadius)){
            if(col.gameObject.CompareTag("Enemy")){
                col.gameObject.GetComponent<EnemyCollisionsHandler>().Die();
            }
        }
    }


    // Self Destruct
    private void SelfDestruct(){
        Destroy(gameObject);
    }
}
