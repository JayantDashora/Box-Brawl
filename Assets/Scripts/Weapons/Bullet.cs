using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables

    [SerializeField] private float speed;

    private void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime *speed);
    }

    // Handling enemy collisions

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }        
        else{
            Destroy(gameObject);
        }
    }
}
