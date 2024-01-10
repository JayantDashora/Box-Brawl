using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDropHandler : MonoBehaviour
{
    // Variables

    [SerializeField] private GameObject obstacle;

    private void Start() {
        
        // Spawning obstacles at random points
        InvokeRepeating("SpawnObstacle",2f,Random.Range(5,10));

    }

    private void SpawnObstacle(){
        Instantiate(obstacle, new Vector3(transform.position.x, 4, transform.position.z), Quaternion.identity);
    }

}