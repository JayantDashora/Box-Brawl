using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // Variables
    private float doubleTapTimeThreshold = 0.2f;
    private float lastTapTime;
    public Action OnDoubleTapped;

    private void Update() {
        if(DoubleTapped()){
            // Use weapon
            OnDoubleTapped?.Invoke();
        }
    }

    // Checking for user input
    private bool DoubleTapped(){

        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if ((touch.phase == TouchPhase.Began) && (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag("Player")))){
                float currentTime = Time.time;
                float timeSinceLastTap = currentTime - lastTapTime;

                if (timeSinceLastTap < doubleTapTimeThreshold){
                    lastTapTime = 0f; // Reset last tap time
                    return true;
                }

                lastTapTime = currentTime;
            }
        }

        return false;
    }
}
