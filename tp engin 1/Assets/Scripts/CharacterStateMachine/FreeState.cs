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

        if (m_stateMachine.RBody.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RBody.velocity = m_stateMachine.RBody.velocity.normalized;
            m_stateMachine.RBody.velocity *= m_stateMachine.MaxVelocity;
        }
        // prendre mouvementVector .z .y et faire la formule apres 
        movementVector = movementVector.normalized;

        float NormalizeSpeed = 0f;

        if (movementVector.z > 0) // Déplacement vers l'avant
        {
            NormalizeSpeed = (movementVector.z * m_stateMachine.m_fowardSpeed) + (movementVector.x * m_stateMachine.m_sidewaySpeed);
        }
        else if (movementVector.z < 0) // Déplacement vers l'arrière
        {
            NormalizeSpeed = (movementVector.z * m_stateMachine.m_backwardSpeed) + (movementVector.x * m_stateMachine.m_sidewaySpeed);
        }
        else // Déplacement sur les côtés
        {
            NormalizeSpeed = Mathf.Abs(movementVector.x) * m_stateMachine.m_sidewaySpeed;
        }

        var vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        vectorOnFloorForward.Normalize(); 

        var vectorOnFloorRight = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
        vectorOnFloorRight.Normalize();

        m_stateMachine.RBody.AddForce(vectorOnFloorForward * NormalizeSpeed, ForceMode.Acceleration);
        m_stateMachine.RBody.AddForce(vectorOnFloorRight * NormalizeSpeed, ForceMode.Acceleration);

        
        m_stateMachine.UpdateAnimatorValue(vectorOnFloorForward, vectorOnFloorRight);
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