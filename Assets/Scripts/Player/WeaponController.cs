using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float doubleTapTimeThreshold = 0.2f;
    private float lastTapTime;
    private float cooldownTime; // Adjust this value for the cooldown time between attacks
    private float cooldownTimer = 0f; // Timer for tracking cooldown
    [SerializeField] private GameObject attackIndicator;

    public Action OnDoubleTapped;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            // Decrement the cooldown timer
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                // Reset cooldown timer when it reaches zero
                cooldownTimer = 0;
            }
        }

        if(cooldownTimer == 0){
            attackIndicator.SetActive(true);
        }
        else{
            attackIndicator.SetActive(false);
        }


        if (DoubleTapped() && cooldownTimer == 0)
        {
            // Use weapon
            OnDoubleTapped?.Invoke();

            // Screen Shake
            CameraShakeEffect.Instance.ScreenShake(7, 0.1f);

            // Getting cooldown time from the weapon
            cooldownTime = transform.GetChild(0).GetComponent<Weapon>().cooldownTime;

            // Put the weapon on cooldown
            cooldownTimer = cooldownTime;
        }
    }

    private bool DoubleTapped()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if ((touch.phase == TouchPhase.Began) && (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Player"))))
            {
                float currentTime = Time.time;
                float timeSinceLastTap = currentTime - lastTapTime;

                if (timeSinceLastTap < doubleTapTimeThreshold)
                {
                    lastTapTime = 0f; // Reset last tap time
                    return true;
                }

                lastTapTime = currentTime;
            }
        }

        return false;
    }

    public void ResetTimer(){
        cooldownTimer = 0;
    }

}
