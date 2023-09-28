using UnityEngine;
public class FreeState : CharacterState
{
    private float DELAY_BETWEEN_STATE = 1.0f;
    private float m_currentTimer = 0.0f;
   
    public override void OnEnter()
    {
        m_currentTimer = DELAY_BETWEEN_STATE;
        Debug.Log("entre free state");
    }
    public override void OnUpdate()
    {
        m_currentTimer -= Time.deltaTime;
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

        m_stateMachine.RB.AddForce(normalizeMovement * NormalizeSpeed, ForceMode.Acceleration);

        m_stateMachine.UpdateAnimatorValues(new Vector2(DirectionalVector.x, DirectionalVector.z));

        //TODO 31 AOÛT:
        //Lorsqu'aucun input est mis, décélérer le personnage rapidement
    }
    public override void OnExit()
    {
        Debug.Log("sortie free state");
    }
    public override bool CanEnter(CharacterState currentState)
    {
        var jumpState = currentState as JumpState;
        var hitState = currentState as HitState;
        var AttackingState = currentState as AttackingState;
        if (jumpState != null)
        {
            //si je suis ici, c est que je suis preetement dans le jump state et test
            //si je peux entre dans freestate
            return m_stateMachine.IsInContactWithFloor();
        }
        if (hitState != null) 
        {
            return true;
        }
        if (AttackingState != null)
        {
            return true;
        }
        return false;
    }
    public override bool CanExit()
    {
        if (m_currentTimer <=0)
        {
            return true;
        }
        return false;
    }
}