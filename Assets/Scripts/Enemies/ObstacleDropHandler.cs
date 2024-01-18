using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDropHandler : MonoBehaviour
{
    // Variables

    [SerializeField] private GameObject obstacle;
    [SerializeField] private ParticleSystem spawnEffect;

    private void Start() {
        
        // Spawning obstacles at random points
        InvokeRepeating("SpawnObstacle",2f,Random.Range(8,14));

    }

    private void SpawnObstacle(){
        Instantiate(spawnEffect, new Vector3(transform.position.x,5, transform.position.z), Quaternion.identity);
        Instantiate(obstacle, new Vector3(transform.position.x,5, transform.position.z), Quaternion.identity);
    }

}
