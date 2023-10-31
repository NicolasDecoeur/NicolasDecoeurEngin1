using System.Collections.Generic;
using UnityEngine;

public class CharacterEffectControler : MonoBehaviour
{
    [SerializeField]
    private List<SpecialEffectsSystem> SpecialEffectsSystem = new List<SpecialEffectsSystem>();

    [SerializeField]
    private AudioSource m_AudioSource;

    public void SpetialEffectPlayer(EActionType actionType)
    {
       foreach (var clip in SpecialEffectsSystem[(int)actionType].audioClips)
       {
            if (clip != null)
            {
                m_AudioSource.clip = clip;
            }
       }

       foreach (var psystem in SpecialEffectsSystem[(int)actionType].particleSystems)
       {
           psystem?.Play();
       }

       m_AudioSource.Play();
    }
}

public enum EActionType
{
    Jumping,
    Landing,
    Hiting,
    count
}

[System.Serializable]
public struct SpecialEffectsSystem
{
    public EActionType actionType;
    public List<AudioClip> audioClips;
    public List<ParticleSystem> particleSystems;
}