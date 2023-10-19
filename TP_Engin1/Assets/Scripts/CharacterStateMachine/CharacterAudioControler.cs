using System.Collections.Generic;
using UnityEngine;

public class CharacterAudioControler : MonoBehaviour
{
    [SerializeField]
    private List<SpecialEffectsSystem> SpecialEffectsSystem = new List<SpecialEffectsSystem>();

    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private AudioClip m_jumpAudioClip;
    [SerializeField]
    private AudioClip m_landingAudioClip;

    public void PlaySound(EActionType soundType)
    {
        switch (soundType)
        {
            case EActionType.Jump:
                m_AudioSource.clip = m_jumpAudioClip;
                break;
            case EActionType.Landing:
                m_AudioSource.clip = m_landingAudioClip;
                break;
            case EActionType.count:
                Debug.LogWarning("sound not found or invalide ");
                break;
            default:
                break;
        }
        m_AudioSource.Play();
    }
}

public enum EActionType
{
    Jump,
    Landing,
    count
}

[System.Serializable]
public struct SpecialEffectsSystem
{
    public EActionType actionType;
    public List<AudioClip> audioClips;
    public List<ParticleSystem> particleSystems;
}