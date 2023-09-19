using UnityEngine;

public class JumpState : CharacterState
{
    //private const float STATE_EXIT_TIMER = 0.2f;
    //private float m_currenteStateTimer = 0.0f;
    public override void OnEnter()
    {
        Debug.Log("entre Jump state");
        m_stateMachine.UpdateAnimatorJump();
        m_stateMachine.RB.AddForce(Vector3.up * m_stateMachine.JumpItencity, ForceMode.Acceleration);
        //m_currenteStateTimer = STATE_EXIT_TIMER;
    }
    public override void OnUpdate()
    { 
        //m_currenteStateTimer -= Time.deltaTime;
        if (m_stateMachine.IsInContactWithFloor())
        {
            m_stateMachine.Animator.SetBool("TouchGround", true);
        }
    }
    public override void OnFixedUpdate()
    {

    }
    public override bool CanEnter(CharacterState currentState)
    {
        //this must be run in update absolutely
        return Input.GetKeyDown(KeyCode.Space);
    }
    public override bool CanExit()
    {
        if (!m_stateMachine.IsInContactWithFloor())
        {
            return false;
        }
        return true;
    }
    public override void OnExit()
    {
        Debug.Log("sortie Jump state");
    }
}