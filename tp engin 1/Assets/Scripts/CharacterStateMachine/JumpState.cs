using UnityEngine;
public class JumpState : CharacterState
{   
    public override void OnEnter()
    {
        Debug.Log("entre Jump state");
        m_stateMachine.RB.AddForce(Vector3.up * m_stateMachine.JumpItencity, ForceMode.Acceleration);
        m_stateMachine.UpdateAnimatorJump();
    }
    public override void OnUpdate()
    { 
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
            m_stateMachine.Animator.SetBool("TouchGround", false);
            return false;
        }
        return true;
    }
    public override void OnExit()
    {
        Debug.Log("sortie Jump state");
    }
}