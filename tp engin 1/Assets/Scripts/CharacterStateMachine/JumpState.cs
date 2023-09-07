using UnityEngine;

public class JumpState : CharacterState
{
    private const float STATE_EXIT_TIMER = 0.2f;
    private float m_currenteStateTimer = 0.0f;
    public override void OnEnter()
    {
        Debug.Log("entre Jump state");

        m_stateMachine.RB.AddForce(Vector3.up * m_stateMachine.JumpItencity, ForceMode.Acceleration);
        m_currenteStateTimer = STATE_EXIT_TIMER;
    }
    public override void OnUpdate()
    { 
        m_currenteStateTimer -= Time.deltaTime;
    }
    public override void OnFixedUpdate()
    {

    }
    public override bool CanEnter()
    {
        //this must be run in update absolutely
        return Input.GetKeyDown(KeyCode.Space);
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

        Debug.Log("sortie Jump state");
    }
}