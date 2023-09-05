using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private Camera m_Camera;
    private Rigidbody m_rb;

    [SerializeField] private float m_accelerationValue;
    [SerializeField] private float m_maxVelocity;  

    void Start()
    {
        m_Camera = Camera.main;
        m_rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var vectorOnFloor = Vector3.ProjectOnPlane(m_Camera.transform.forward, Vector3.up);
      
        vectorOnFloor.Normalize();

        if (Input.GetKey(KeyCode.W)) // up
        {
            m_rb.AddForce(vectorOnFloor * m_accelerationValue, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S)) // down
        {
            m_rb.AddForce(vectorOnFloor * m_accelerationValue, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A)) // left
        {
            m_rb.AddForce(vectorOnFloor * m_accelerationValue, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D)) // right
        {
            m_rb.AddForce(vectorOnFloor * m_accelerationValue, ForceMode.Acceleration);
        }

        if (m_rb.velocity.magnitude > m_maxVelocity)
        {
            m_rb.velocity = m_rb.velocity.normalized;
            m_rb.velocity *= m_maxVelocity;
        }

        //TODO 31 AO�T:
            //Appliquer les d�placements relatifs � la cam�ra dans les 3 autres directions
            //Avoir des vitesses de d�placements maximales diff�rentes vers les c�t�s et vers l'arri�re
            //Lorsqu'aucun input est mis, d�c�l�rer le personnage rapidement

        Debug.Log(m_rb.velocity.magnitude);
    }
}