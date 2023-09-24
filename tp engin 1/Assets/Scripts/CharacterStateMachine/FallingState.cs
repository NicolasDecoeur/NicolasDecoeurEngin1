using UnityEngine;

public class FallingState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("entre falling state");
    }

    public override void OnExit()
    {
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnUpdate()
    {
    }

    public override bool CanEnter(CharacterState currentState)
    {
        return false;
    }

    public override bool CanExit()
    {
        Debug.Log("sortie falling state");
        return true;
    }
}