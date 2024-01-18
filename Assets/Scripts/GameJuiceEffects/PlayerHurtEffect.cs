using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtEffect : MonoBehaviour
{

    private Animator healthBarAnimator;
    private Animator screenTintAnimator;
    private void Start() {
        healthBarAnimator = GameObject.Find("Canvas/HealthBar").GetComponent<Animator>();
        screenTintAnimator = GameObject.Find("Canvas/Misc/PlayerHurtScreenTint").GetComponent<Animator>();
    }

    public void PlayerHurt(){
        healthBarAnimator.SetTrigger("Pop");
        screenTintAnimator.SetTrigger("Blink");
        CameraShakeEffect.Instance.ScreenShake(10,0.2f);
    }

}
