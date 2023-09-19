using System.Threading;
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

    /*   public override void OnFixedUpdate()
       {
           Vector3 directionMovement = Vector3.zero;

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
           directionMovement = directionMovement.normalized;

           float NormalizeSpeed = 0f;
           if (directionMovement.z > 0) // Déplacement vers l'avant
           {
               NormalizeSpeed = ((directionMovement.z * m_stateMachine.m_fowardSpeed) + (directionMovement.x * m_stateMachine.m_sidewaySpeed));
               Debug.Log(NormalizeSpeed + "avant");
           }
           else if (directionMovement.z < 0) // Déplacement vers l'arrière
           {
               NormalizeSpeed = ((directionMovement.z * m_stateMachine.m_backwardSpeed) + (directionMovement.x * m_stateMachine.m_sidewaySpeed));
               Debug.Log(NormalizeSpeed + "arriere");
           }
           else // Déplacement sur les côtés
           {
               NormalizeSpeed = m_stateMachine.m_sidewaySpeed;
               Debug.Log(NormalizeSpeed + "cote");
           }

           Vector3 vectorOnFloorForward = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.forward, Vector3.up);
           vectorOnFloorForward.Normalize();
           Vector3 vectorOnFloorSideway = Vector3.ProjectOnPlane(m_stateMachine.Camera.transform.right, Vector3.up);
           vectorOnFloorSideway.Normalize();

           Vector3 movementVector = Vector3.zero;
           movementVector = vectorOnFloorForward + vectorOnFloorSideway;
           movementVector = movementVector.normalized;

           //Debug.Log(vectorOnFloor);
           if (NormalizeSpeed != 0)
           {
               m_stateMachine.RB.AddForce(movementVector * NormalizeSpeed, ForceMode.Acceleration);
           }
           //else if (NormalizeSpeed < 0)
           //{
           //    m_stateMachine.RB.AddForce(movementVector * -NormalizeSpeed, ForceMode.Acceleration);
           //}

           m_stateMachine.UpdateAnimatorValues(new Vector2(movementVector.x, movementVector.z));

           //TODO 31 AOÛT:
           //Avoir des vitesses de déplacements maximales différentes vers les côtés et vers l'arrière
           //Lorsqu'aucun input est mis, décélérer le personnage rapidement
       }*/

    public override void OnFixedUpdate()
    {

        // trouver et normaliser la direction du vector de deplacement ok

        // calculer la vitesse maximal 

        // trouver la direction au sol ok

        // apliquer l aceleration

        // limiter la vitesse maximal

        // apliquer les animation 

        Vector3 directionMovement = Vector3.zero;

        // trouver et normaliser la direction du vector de deplacement

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

        // calculer la vitesse maximal

        float NormalizeSpeed = 0f;

        // formule pas bonne 

        // exp ((3/4) * 20 = (1/4) *5) == 15 + 1.25 == 16.25 

        if (directionMovement.z > 0) // Déplacement vers l'avant
        {
            NormalizeSpeed = ((directionMovement.z * m_stateMachine.m_fowardSpeed) + (directionMovement.x * m_stateMachine.m_sidewaySpeed));
            Debug.Log(directionMovement.z + " avant " + directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
        }     
        else if (directionMovement.z < 0) // Déplacement vers l'arrière
        {
            NormalizeSpeed = ((directionMovement.z * m_stateMachine.m_backwardSpeed) + (directionMovement.x * m_stateMachine.m_sidewaySpeed));
            Debug.Log(directionMovement.z + " arriere " + directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
        }
        else if (directionMovement.x !=0 ) // Déplacement sur les côtés
        {
            NormalizeSpeed = m_stateMachine.m_sidewaySpeed;
            Debug.Log(directionMovement.x + " cote " + NormalizeSpeed + " vitesse ");
        }

        // apliquer l aceleration

        // limiter la vitesse maximal

        m_stateMachine.RB.AddForce(directionMovement * m_stateMachine.AccelerationFowardValue, ForceMode.Acceleration);

        // apliquer les animation 

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