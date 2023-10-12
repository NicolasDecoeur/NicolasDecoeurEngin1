using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    protected bool m_canBeHit = false;
    [SerializeField]
    protected bool m_canHit = false;
    [SerializeField]
    protected EAgentType m_agentType = EAgentType.Count;
    [SerializeField]
    protected List<EAgentType> m_affectedAgentType = new List<EAgentType>();

    private void OnTriggerEnter(Collider other)
    {
        var otherHitBox = other.GetComponent<HitBox>();
        if (otherHitBox == null) { return; }

        CanHitOther(otherHitBox);
    }

    protected bool CanHitOther(HitBox other)
    {
        return ((m_canHit && other.m_canBeHit) &&
             (m_affectedAgentType.Contains(other.m_agentType)));
    }
    
    protected void GetHit(HitBox otherHitBox)
    {
        //debug qui dit qui ses fait fraper 
        //(gameobject.name)
    }
}

public enum EAgentType
{
    Ally,
    Ennemy,
    Neutral,
    Count
}