using UnityEngine;

public class FallingState : CharacterState
{
    //float m_initialHeight = 0.0f;
    //float m_currentHeight = 0.0f;
    public override void OnEnter()
    {
        Debug.Log("entre falling state");
    }
    public override void OnUpdate()
    {
    }
    public override void OnFixedUpdate()
    {
    }
    public override void OnExit()
    {
        Debug.Log("sortie falling state");
    }
    public override bool CanEnter(CharacterState currentState)
    {
        //if (Input.GetKeyDown(KeyCode.F)) 
        //{
        //    return true;
        //}
        return false;
    }

    public override bool CanExit()
    {
        return true;
    }
}