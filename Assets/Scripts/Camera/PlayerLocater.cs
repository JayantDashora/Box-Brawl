using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerLocater : MonoBehaviour
{
    // Variables

    CinemachineVirtualCamera virtualCamera;
    GameObject playerReference;
    void Start(){

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        playerReference = GameObject.FindGameObjectWithTag("Player");
        virtualCamera.m_Follow = playerReference.transform;

    }


}
