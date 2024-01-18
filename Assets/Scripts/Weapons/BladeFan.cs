using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeFan : MonoBehaviour
{
    // Kills one enemy on collision with enemy
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyCollisionsHandler>().Die();
            Destroy(gameObject);
        }
    }


}
