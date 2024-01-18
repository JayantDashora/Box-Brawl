using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nuke : MonoBehaviour
{

    // Variables

    [SerializeField] private Animator screenTintAnimator;

    private void Start() {
        screenTintAnimator = GameObject.Find("Canvas/Misc/NukeTint").GetComponent<Animator>();
        Blast();
    }


    private void Blast(){

        // Destroy all the enemies on the screen

        BlastGameJuice();

        foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
            enemy.GetComponent<EnemyCollisionsHandler>().Die();
        }

    }


    // Game juice effect for the big blast that covers the whole screen

    private void BlastGameJuice(){
        screenTintAnimator.Play("Flash");
        CameraShakeEffect.Instance.ScreenShake(15f,0.3f);
    }


}
