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
   /* public override void OnFixedUpdate()
    {
        Vector3 movementVector = Vector3.zero;
        bool isKeyPressed = false;

        if (Input.GetKey(KeyCode.W)) // up
        {
            movementVector += Vector3.forward;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            movementVector += Vector3.back;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            movementVector += Vector3.left;
            isKeyPressed = true;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            movementVector += Vector3.right;
            isKeyPressed = true;
        }
        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }
        // prendre mouvementVector .z .y et faire la formule apres 
        movementVector = movementVector.normalized;

        float NormalizeSpeed = 0f;

        if (movementVector.z > 0 && isKeyPressed == true) // Déplacement vers l'avant
        {
            NormalizeSpeed = ((movementVector.z * m_stateMachine.m_fowardSpeed) + (movementVector.x * m_stateMachine.m_sidewaySpeed));
        }
        else if (movementVector.z < 0 && isKeyPressed == true) // Déplacement vers l'arrière
        {
            NormalizeSpeed = ((movementVector.z * m_stateMachine.m_backwardSpeed) + (movementVector.x * m_stateMachine.m_sidewaySpeed));
        }
        else if (isKeyPressed == true) // Déplacement sur les côtés
        {
            NormalizeSpeed = m_stateMachine.m_sidewaySpeed;
        }

        var vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        vectorOnFloorForward.Normalize(); 

        var vectorOnFloorSideway = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
        vectorOnFloorSideway.Normalize();

        m_stateMachine.RB.AddForce(vectorOnFloorForward * NormalizeSpeed, ForceMode.Acceleration);
        //m_stateMachine.RB.AddForce(vectorOnFloorSideway * NormalizeSpeed, ForceMode.Acceleration);
       

        //m_stateMachine.UpdateAnimatorValue(vectorOnFloorForward, vectorOnFloorForward);
        float forwardComponent = Vector3.Dot(m_stateMachine.RB.velocity, vectorOnFloorForward);
        float sidewayComponent = Vector3.Dot(m_stateMachine.RB.velocity, vectorOnFloorSideway);

        m_stateMachine.UpdateAnimatorValues(new Vector2(sidewayComponent, forwardComponent));

        //TODO 31 AOÛT:
        //Avoir des vitesses de déplacements maximales différentes vers les côtés et vers l'arrière
        //Lorsqu'aucun input est mis, décélérer le personnage rapidement

        //Debug.Log(m_stateMachine.RB.velocity.magnitude);
    }*/

    public override void OnFixedUpdate()
    {
        var vectorOnFloor = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W)) // up
        {
            vectorOnFloor += Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            vectorOnFloor += Vector3.ProjectOnPlane(-m_stateMachine.Camera.transform.forward, Vector3.up);
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            vectorOnFloor += Vector3.ProjectOnPlane(-m_stateMachine.Camera.transform.right, Vector3.up);
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            vectorOnFloor += Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
        }
        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }

        vectorOnFloor.Normalize();

        float NormalizeSpeed = 0f;

        if (vectorOnFloor.z > 0) // Déplacement vers l'avant
        {
            NormalizeSpeed = ((vectorOnFloor.z * m_stateMachine.m_fowardSpeed) + (vectorOnFloor.x * m_stateMachine.m_sidewaySpeed));
            Debug.Log(NormalizeSpeed + "avant");
        }
        else if (vectorOnFloor.z < 0) // Déplacement vers l'arrière
        {
            NormalizeSpeed = ((vectorOnFloor.z * m_stateMachine.m_backwardSpeed) + (vectorOnFloor.x * m_stateMachine.m_sidewaySpeed));
            Debug.Log(NormalizeSpeed + "arriere");
        }
        else // Déplacement sur les côtés
        {
            NormalizeSpeed = m_stateMachine.m_sidewaySpeed;
            Debug.Log(NormalizeSpeed + "cote");
        }

        //Debug.Log(vectorOnFloor);
        if (NormalizeSpeed > 0 )
        m_stateMachine.RB.AddForce(vectorOnFloor * NormalizeSpeed, ForceMode.Acceleration);
        
        else if (NormalizeSpeed < 0)
        m_stateMachine.RB.AddForce(vectorOnFloor * -NormalizeSpeed, ForceMode.Acceleration);

     m_stateMachine.UpdateAnimatorValues(new Vector2(vectorOnFloor.x, vectorOnFloor.z));

        //TODO 31 AOÛT:
        //Avoir des vitesses de déplacements maximales différentes vers les côtés et vers l'arrière
        //Lorsqu'aucun input est mis, décélérer le personnage rapidement
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