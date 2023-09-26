using UnityEngine;

public class OnGrondState : CharacterState
{
    private const float STATE_EXIT_TIMER = 2f;
    private float m_currenteStateTimer = 0.0f;
    public override void OnEnter()
    {
        m_currenteStateTimer = STATE_EXIT_TIMER;
        m_stateMachine.UpdateAnimatorOnGround();
        Debug.Log("entre onGround state");
    }
    public override void OnUpdate()
    {
        m_currenteStateTimer -= Time.deltaTime;
    }
    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        Debug.Log("sortie onGround state");
    }

    public override bool CanEnter(CharacterState currentState)
    {
        if (Input.GetKeyDown(KeyCode.G)) 
        {
            return true;
        }
        return false;
    }

    public override bool CanExit()
    {
        if (m_currenteStateTimer <= 0.0f)
        {
            return true;
        }
        return false;
    }
}
