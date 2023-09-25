using UnityEngine;

public class AttackingState : CharacterState
{
    public override void OnEnter()
    {
        m_stateMachine.UpdateAnimatorAttacking();
        Debug.Log("entre attacking state");
    }

    public override void OnUpdate()
    {
    }
    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        Debug.Log("sortie attacking state");
    }

    public override bool CanEnter(CharacterState currentState)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            return true;
        }
        return false;
    }

    public override bool CanExit()
    {       
        return true;
    }
}
