using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nuke : MonoBehaviour
{

    private void Start() {
        Blast();
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


}
