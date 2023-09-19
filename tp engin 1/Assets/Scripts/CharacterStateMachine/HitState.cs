using UnityEngine;

public class HitState : CharacterState
{
    private const float STATE_EXIT_TIMER = 1f;
    private float m_currenteStateTimer = 0.0f;
    public override void OnEnter()
    {
        Debug.Log("entre Hit state");
        m_currenteStateTimer = STATE_EXIT_TIMER;
    }
    public override void OnUpdate()
    {
        m_currenteStateTimer -= Time.deltaTime;
    }
    public override void OnFixedUpdate()
    {

    }
    public override bool CanEnter(CharacterState currentState)
    {
        //this must be run in update absolutely
        return Input.GetKeyDown(KeyCode.H);
    }
    public override bool CanExit()
    {
        if (m_currenteStateTimer <= 0.0f)
        {
            return true;
        }
        return false;
    }
    public override void OnExit()
    {

        Debug.Log("sortie Hit state");
    }
}