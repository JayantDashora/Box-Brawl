using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeFan : MonoBehaviour
{
    // Kills one enemy on collision with enemy
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy")){
            BladeFanEffect();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    // Fan attacks effects ( When fan attacks the enemy) ( Game Juice Effect)
    private void BladeFanEffect(){

    }

}
