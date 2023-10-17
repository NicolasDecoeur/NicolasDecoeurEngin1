using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField]
    protected bool m_canHit;
    [SerializeField]
    protected bool m_canReciveHits;
    [SerializeField]
    protected EAgentType m_agentType = EAgentType.Count;
    [SerializeField]
    protected List<EAgentType> m_affectedAgentTypes = new List<EAgentType>();

    protected void OnTriggerEnter(Collider other)
    {
        var otherHitBox = other.gameObject.GetComponent<HitBox>();
        if (otherHitBox == null) { return; }

        if (CanHitOther(otherHitBox))
        {
            VFXManager._Instance.InstantiateVFX(EVFX_TYPE.Hit, other.ClosestPoint(transform.position));
            otherHitBox.GetHit(this);
        }
    }

    protected bool CanHitOther(HitBox other)
    {
        return (m_canHit &&
         other.m_canReciveHits &&
         m_affectedAgentTypes.Contains(other.m_agentType));
    }

    protected void GetHit(HitBox otherHitBox)
    {
        Debug.Log(gameObject.name + " got hit by: " + otherHitBox);
    }
}
public enum EAgentType
{
    Ally,
    Enemy,
    Neutral,
    Count
}