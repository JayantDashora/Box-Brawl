using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    private float doubleTapTimeThreshold = 0.2f;
    private float cooldownTime; // Adjust this value to set the cooldown time
    private float lastTapTime;
    private bool isOnCooldown = false;
    
    public Action OnDoubleTapped;

    private void Update()
    {
        if (!isOnCooldown && DoubleTapped())
        {
            // Use weapon
            OnDoubleTapped?.Invoke();

            // Update the cooldown time value
            cooldownTime = transform.GetChild(0).GetComponent<Weapon>().cooldownTime;

            // Start the cooldown timer
            StartCoroutine(StartCooldown());
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

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
}
