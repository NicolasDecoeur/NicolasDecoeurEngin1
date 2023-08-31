using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform m_objectToFollow;
    private Vector3 m_offset = Vector3.zero;
    public float m_smoothSpeed = 0.5f;

    private void Start()
    {
        m_offset = transform.position - m_objectToFollow.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = m_objectToFollow.position + m_offset;
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, desiredPosition, m_smoothSpeed);
        transform.SetPositionAndRotation(lerpedPosition, transform.rotation);
    }
}
