using System.Collections.Generic;
using UnityEngine;

public class CharacterEffectControler : MonoBehaviour
{
    [SerializeField]
    private List<SpecialEffectsSystem> SpecialEffectsSystem = new List<SpecialEffectsSystem>();

    [SerializeField]
    private AudioSource m_AudioSource;
    //[SerializeField]
    //private AudioClip m_jumpAudioClip;
    //[SerializeField]
    //private AudioClip m_landingAudioClip;

    public void PlaySound(EActionType actionType)
    {
       foreach (var clip in SpecialEffectsSystem[(int)actionType].audioClips)
       {
            if (clip != null)
            {
                m_AudioSource.clip = clip;
            }
       }
        foreach (var psystem  in SpecialEffectsSystem[(int)actionType].particleSystems)
        {
            psystem?.Play();
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

/*using System.Collections.Generic;
using UnityEngine;

public class CharacterEffectControler : MonoBehaviour
{
    [SerializeField]
    private List<SpecialEffectsSystem> SpecialEffectsSystem = new List<SpecialEffectsSystem>();

    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private AudioClip m_jumpAudioClip;
    [SerializeField]
    private AudioClip m_landingAudioClip;

    public void PlaySound(EActionType actionType)
    {
        switch (actionType)
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
}*/