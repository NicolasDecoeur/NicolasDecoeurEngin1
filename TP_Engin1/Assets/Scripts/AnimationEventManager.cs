using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private CharacterControllerStateMachine m_stateMachine;

    private void Awake()
    {
        m_stateMachine = GetComponent<CharacterControllerStateMachine>();
    }

    public void ActivateHitBox()
    {
        m_stateMachine.OnEnableAttackHitbox(true);
    }

    public void DisableHitBox()
    {
        m_stateMachine.OnEnableAttackHitbox(false);
    }
}