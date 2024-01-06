using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected WeaponController weaponControllerRef;
    [SerializeField] protected GameObject spawnObject;

    [SerializeField] protected bool doesSpawnAnything;
    protected void OnEnable() {

        weaponControllerRef = GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<WeaponController>();

        if(doesSpawnAnything){
            weaponControllerRef.OnDoubleTapped = SpawnAttack;
        }
        else{
            weaponControllerRef.OnDoubleTapped = Attack;
        }

    }


    protected void OnDisable() {
        weaponControllerRef.OnDoubleTapped = null;
    }

    protected virtual void SpawnAttack(){
        GameJuiceEffects();
        Instantiate(spawnObject,new Vector3(transform.position.x ,2, transform.position.z),Quaternion.identity);
    } 

    protected virtual void Attack(){
        // Attack for the specific weapon
    }

   
    protected virtual void GameJuiceEffects(){
        // Game juice effects for weapon use ( Common for spawning any weapon )
    }
}