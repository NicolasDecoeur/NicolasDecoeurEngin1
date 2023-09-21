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
        // trouver et normaliser la direction du vector de deplacement ok
        // calculer la vitesse maximal ok 75%
        // trouver la direction au sol ok
        // apliquer l aceleration ok 
        // limiter la vitesse maximal ok
        // apliquer les animation ok
        Vector3 directionMovement = Vector3.zero;
        // trouver et normaliser la direction du vector de deplacement ok

        if (Input.GetKey(KeyCode.W)) // up
        {
            directionMovement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            directionMovement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            directionMovement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            directionMovement += Vector3.right;
        }
        if (m_stateMachine.RB.velocity.magnitude > m_stateMachine.MaxVelocity)
        {
            m_stateMachine.RB.velocity = m_stateMachine.RB.velocity.normalized;
            m_stateMachine.RB.velocity *= m_stateMachine.MaxVelocity;
        }

        // trouver la direction au sol ok
        Vector3 vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward * directionMovement.z, Vector3.up);   
        Vector3 vectorOnFloorSideway = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right * directionMovement.x, Vector3.up);

        Vector3 movementVector = Vector3.zero;
        movementVector = vectorOnFloorForward + vectorOnFloorSideway;
        movementVector.Normalize();

        // calculer la vitesse maximal ok 75%

        float NormalizeSpeed = 0f;

        float inputMagnitude = directionMovement.magnitude;

        if (inputMagnitude > 1.0f)
        {
            directionMovement /= inputMagnitude;
        }

        if (directionMovement.z > 0) // Déplacement vers l'avant
        {
            if (directionMovement.x != 0)
            {
                NormalizeSpeed = (Mathf.Abs(directionMovement.z) * m_stateMachine.m_fowardSpeed) + (Mathf.Abs(directionMovement.x) * m_stateMachine.m_sidewaySpeed);
                Debug.Log(directionMovement.z + " avant " + directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
            }
            else
            {
                NormalizeSpeed = m_stateMachine.m_fowardSpeed;
                Debug.Log(directionMovement.z + " avant " + NormalizeSpeed + " vitesse ");
            }
        }
        else if (directionMovement.z < 0) // Déplacement vers l'arrière
        {
            if (directionMovement.x != 0)
            {
                NormalizeSpeed = (Mathf.Abs(directionMovement.z) * m_stateMachine.m_backwardSpeed) + (Mathf.Abs(directionMovement.x) * m_stateMachine.m_sidewaySpeed);
                Debug.Log(directionMovement.z + " arriere " + directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
            }
            else
            {
                NormalizeSpeed = m_stateMachine.m_backwardSpeed;
                Debug.Log(directionMovement.z + " arriere " + NormalizeSpeed + " vitesse ");
            }
        }
        else if (directionMovement.x != 0) // Déplacement sur les côtés
        {
            NormalizeSpeed = m_stateMachine.m_sidewaySpeed;
            Debug.Log(directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
        }

        // apliquer l aceleration ok
        // limiter la vitesse maximal ok

        m_stateMachine.RB.AddForce(movementVector * NormalizeSpeed, ForceMode.Acceleration);

        // apliquer les animation ok

        m_stateMachine.UpdateAnimatorValues(new Vector2(directionMovement.x, directionMovement.z));

        //TODO 31 AOÛT:
        //Avoir des vitesses de déplacements maximales différentes vers les côtés et vers l'arrière
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
        if (jumpState != null)
        {
            //si je suis ici, c est que je suis preetement dans le jump state et test
            // si je peux entre dans freestate
            return m_stateMachine.IsInContactWithFloor();
        }
        if (hitState != null) 
        {
            return true;
        }
        return false;
    }
    public override bool CanExit()
    {
        return true;
    }
}