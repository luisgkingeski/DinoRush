using UnityEngine;
using Cinemachine;
using System.Collections;

public class CinechineShake : MonoBehaviour
{
    public static CinechineShake Instance { get; private set; }

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer = 0;
    //  private float shakeTimerTotal;
    // private float startingIntersity;


    private void Start()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }


    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        // startingIntersity = intensity;
        // shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                           cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
                //cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 
                //    Mathf.Lerp(startingIntersity, 0f, shakeTimer / shakeTimerTotal);                 
            }
        }
    }
}