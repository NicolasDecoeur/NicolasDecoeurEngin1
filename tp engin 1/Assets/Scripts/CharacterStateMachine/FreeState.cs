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
        int numberOfInputs = 0;
        float speed = 0;


        if (Input.GetKey(KeyCode.W)) // up
        {
            movementVector += Vector3.forward;
            numberOfInputs++;
            speed += m_stateMachine.m_fowardSpeed;
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            movementVector += Vector3.back;
            numberOfInputs++;
            speed += m_stateMachine.m_backwardSpeed;
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            movementVector += Vector3.left;
            numberOfInputs++;
            speed += m_stateMachine.m_sidewaySpeed;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            movementVector += Vector3.right;
            numberOfInputs++;
            speed += m_stateMachine.m_sidewaySpeed;
        }

        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }

        float normalizeSpeed = 0;
        if (numberOfInputs != 0)
        {
            normalizeSpeed = speed / numberOfInputs;
        }

        movementVector = movementVector.normalized;

        var vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        vectorOnFloorForward.Normalize(); 

        var vectorOnFloorRight = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
        vectorOnFloorRight.Normalize();

        m_stateMachine.RB.AddForce(vectorOnFloorForward * movementVector.z * normalizeSpeed, ForceMode.Acceleration);
        m_stateMachine.RB.AddForce(vectorOnFloorRight * movementVector.x * normalizeSpeed, ForceMode.Acceleration);

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