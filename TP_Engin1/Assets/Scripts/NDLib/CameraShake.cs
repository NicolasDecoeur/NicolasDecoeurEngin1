using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake _Instance { get; private set; }

    private const float SHAKE_TIMER_SETUP = 0.5f;

    [SerializeField]
    private CinemachineVirtualCamera m_camera;

    [SerializeField]
    private float m_shakeTimer = 0f;
    [SerializeField]
    private float m_shakeIntensity = 2f;

    private void Awake()
    {
        _Instance = this;
    }

    private void Update()
    {
        if (m_shakeTimer > 0)
        {
            m_shakeTimer -= Time.deltaTime;
            if (m_shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin m_cameraShake =
                     m_camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                m_cameraShake.m_AmplitudeGain = 0f;
            }
        }
    }

    public void ShakeOnHit()
    {
        CinemachineBasicMultiChannelPerlin m_cameraShake =
            m_camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        m_cameraShake.m_AmplitudeGain = m_shakeIntensity;

        m_shakeTimer = SHAKE_TIMER_SETUP;
    }
}
