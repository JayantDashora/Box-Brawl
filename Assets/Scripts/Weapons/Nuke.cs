using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    // Variables

    [SerializeField] private float cooldownTime;
    private void Start() {

        if(GameObject.FindGameObjectsWithTag("Nuke").Length > 1 && GameObject.FindGameObjectsWithTag("Nuke")[0] != this.gameObject){
            Destroy(gameObject);
        }
        else{
            Blast();
            Invoke("SelfDestruct", cooldownTime);
        }

    }


    private void Blast(){

        // Destroy all the enemies on the screen

        BlastGameJuice();

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
            Destroy(enemy);
        }

    }


    // Game juice effect for the big blast that covers the whole screen

    private void BlastGameJuice(){
        // Game juice effect for the big blast that covers the whole screen
    }

    private void SelfDestruct(){
        Destroy(gameObject);
    }


}
