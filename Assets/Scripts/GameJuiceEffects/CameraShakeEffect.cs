using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShakeEffect : MonoBehaviour
{
    // Variables

    public static CameraShakeEffect Instance {get; private set;}
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shaketimer;

    private void Awake() {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Screen shake function
    public void ScreenShake(float intensity, float duration){
        CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = intensity;

        shaketimer = duration;
    }


    // Used to manage the time duration fo the effect
    private void Update() {

        shaketimer -= Time.deltaTime;

        if(shaketimer <= 0){
            CinemachineBasicMultiChannelPerlin noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = 0f;
        }


    }
}
