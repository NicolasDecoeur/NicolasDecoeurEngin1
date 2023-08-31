using UnityEngine;

public class CharacterControler : MonoBehaviour
{
    private Camera m_Camera;
    private Rigidbody m_rb;

    [SerializeField] private float m_accelerationValue;
    [SerializeField] private float m_maxVelocity;  

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var vectorOnFloor = Vector3.ProjectOnPlane(m_Camera.transform.forward, Vector3.up);
        
        vectorOnFloor.Normalize();

        if (Input.GetKey(KeyCode.W))
        {
            m_rb.AddForce(vectorOnFloor * m_accelerationValue, ForceMode.Acceleration);
        }
        if (m_rb.velocity.magnitude > m_maxVelocity)
        {
            m_rb.velocity = m_rb.velocity.normalized;
            m_rb.velocity *= m_maxVelocity;
        }
    }
}