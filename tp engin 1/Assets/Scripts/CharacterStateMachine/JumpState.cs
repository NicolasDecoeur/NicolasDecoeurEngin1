using UnityEngine;
public class JumpState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("entre Jump state");
        m_stateMachine.RB.AddForce(Vector3.up * m_stateMachine.JumpItencity, ForceMode.Impulse);
        m_stateMachine.UpdateAnimatorJump();
    }
    public override void OnUpdate()
    {
    }
    public override void OnFixedUpdate()
    {
    }
    public override void OnExit()
    {
        Debug.Log("sortie Jump state");
    }

    public override bool CanEnter(CharacterState currentState)
    {
        //this must be run in update absolutely
        return Input.GetKeyDown(KeyCode.Space);
    }
    public override bool CanExit()
    {
         return true;     
    }
}