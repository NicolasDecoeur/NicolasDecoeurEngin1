using UnityEngine;

public class FreeState : CharacterState
{
    public override void OnEnter()
    {
        Debug.Log("entre free state");
    }

    public override void OnUpdate()
    {
    }

    public override void OnFixedUpdate()
    {
        Vector3 movementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) // up
        {
            movementVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            movementVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            movementVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            movementVector += Vector3.right;
        }

        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }

        movementVector = movementVector.normalized; 

        var vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        vectorOnFloorForward.Normalize(); 
        var vectorOnFloorRight = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
        vectorOnFloorRight.Normalize();

        m_stateMachine.RB.AddForce(vectorOnFloorForward * movementVector.z * m_stateMachine.AccelerationFowardValue, ForceMode.Acceleration);
        m_stateMachine.RB.AddForce(vectorOnFloorRight * movementVector.x * m_stateMachine.AccelerationSideValue, ForceMode.Acceleration);

        //TODO 31 AOÛT:
        //Avoir des vitesses de déplacements maximales différentes vers les côtés et vers l'arrière
        //Lorsqu'aucun input est mis, décélérer le personnage rapidement

        //Debug.Log(m_stateMachine.RB.velocity.magnitude);
    }
    public override void OnExit()
    {
        Debug.Log("sortie free state");
    }
    public override bool CanEnter()
    {

        return m_stateMachine.IsInContactWithFloor();
    }
    public override bool CanExit()
    {
        return true;
    }
}