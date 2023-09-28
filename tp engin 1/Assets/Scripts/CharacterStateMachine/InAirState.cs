using UnityEngine;

public class InAirState : CharacterState
{
    private float InAirMovementPenality = 0.3f;
    public override void OnEnter()
    {
        Debug.Log("entre InAir state");
    }
    public override void OnUpdate()
    {
    }
    public override void OnFixedUpdate()
    {
        Vector3 DirectionalVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            DirectionalVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            DirectionalVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            DirectionalVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            DirectionalVector += Vector3.right;
        }

        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }

        Vector3 vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward * DirectionalVector.z, Vector3.up);
        Vector3 vectorOnFloorSideway = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right * DirectionalVector.x, Vector3.up);

        Vector3 normalizeMovement = Vector3.zero;
        normalizeMovement = vectorOnFloorForward + vectorOnFloorSideway;
        normalizeMovement.Normalize();

        float NormalizeSpeed = 0f;

        float inputMagnitude = DirectionalVector.magnitude;

        if (inputMagnitude > 1.0f)
        {
            DirectionalVector /= inputMagnitude;
        }

        if (DirectionalVector.z > 0)
        {
            if (DirectionalVector.x != 0)
            {
                NormalizeSpeed = (Mathf.Abs(DirectionalVector.z) * m_stateMachine.m_maxFowardSpeed) + (Mathf.Abs(DirectionalVector.x) * m_stateMachine.m_maxSidewaySpeed);
            }
            else
            {
                NormalizeSpeed = m_stateMachine.m_maxFowardSpeed;
            }
        }
        else if (DirectionalVector.z < 0)
        {
            if (DirectionalVector.x != 0)
            {
                NormalizeSpeed = (Mathf.Abs(DirectionalVector.z) * m_stateMachine.m_maxBackwardSpeed) + (Mathf.Abs(DirectionalVector.x) * m_stateMachine.m_maxSidewaySpeed);
            }
            else
            {
                NormalizeSpeed = m_stateMachine.m_maxBackwardSpeed;
            }
        }
        else if (DirectionalVector.x != 0)
        {
            NormalizeSpeed = m_stateMachine.m_maxSidewaySpeed;
        }

        m_stateMachine.RB.AddForce(normalizeMovement * NormalizeSpeed * InAirMovementPenality, ForceMode.Acceleration);
    }
    public override void OnExit()
    {
        Debug.Log("sortie InAir state");
    }
    public override bool CanEnter(CharacterState currentState)
    {
        var jumpState = currentState as JumpState;
        if (jumpState != null)
        {        
            return m_stateMachine.IsInContactWithFloor();
        }
        return false;
    }
    public override bool CanExit()
    {
        if (m_stateMachine.IsInContactWithFloor())
        { 
            return true; 
        }
        return false;
    }
}