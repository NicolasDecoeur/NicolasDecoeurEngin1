using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_objectToLookAt;
    [SerializeField] private Transform m_camera;
    [SerializeField] private Vector2 m_clampingXRotationValues = Vector2.zero;
    [SerializeField] private float m_desiredDistance;
    [SerializeField] private float m_closePointToObject = 3.92f;
    [SerializeField] private float m_farthestPointToObject = 10.0f;
    [SerializeField] private float m_smoothSpeed = 0.5f;
    [SerializeField] private float m_rotationSpeed = 1.0f;
    private bool m_isCameraBlock = false;

    void Update()
    {
        UpdateHorizontalMovements();
        UpdateVerticalMovements();
        if (m_isCameraBlock == false)
        {
            UpdateCameraScroll();
        }
    }

    private void FixedUpdate()
    {
        MoveCameraInFrontOfObstructionFUpdate();
    }

    private void UpdateHorizontalMovements()
    {
        float currentAngleX = Input.GetAxis("Mouse X") * m_rotationSpeed;
        transform.RotateAround(m_objectToLookAt.position, m_objectToLookAt.up, currentAngleX);
    }

    private void UpdateVerticalMovements()
    {
        float currentAngleY = Input.GetAxis("Mouse Y") * m_rotationSpeed;
        float eulersAngleX = transform.rotation.eulerAngles.x;
        float comparisonAngle = eulersAngleX + currentAngleY;

        comparisonAngle = ClampAngle(comparisonAngle);

        if ((currentAngleY < 0 && comparisonAngle < m_clampingXRotationValues.x)
           || (currentAngleY > 0 && comparisonAngle > m_clampingXRotationValues.y))
        {
            return;
        }
        transform.RotateAround(m_objectToLookAt.position, transform.right, currentAngleY);
    }

     private void UpdateCameraScroll()
     {
        float scrollDelta = Input.mouseScrollDelta.y;
        float cameraDistance = 0;

        if (scrollDelta != 0)
        {
             m_desiredDistance -= scrollDelta;
        }

        m_desiredDistance = Mathf.Clamp(m_desiredDistance, m_closePointToObject, m_farthestPointToObject);

        cameraDistance = Vector3.Distance(m_objectToLookAt.position, m_camera.position);

        float lerpDirection = Mathf.Lerp(cameraDistance, m_desiredDistance, m_smoothSpeed);

        float frameLerpingDistance = cameraDistance - lerpDirection;

        m_camera.Translate(Vector3.forward * frameLerpingDistance, Space.Self);
     }

    private void MoveCameraInFrontOfObstructionFUpdate()
    {
       
        int layerMask = 1 << 8;

        RaycastHit hit;

        var vecteurdiff = transform.position - m_objectToLookAt.position;
        var distance = vecteurdiff.magnitude;

        if (Physics.Raycast(m_objectToLookAt.position, vecteurdiff, out hit, distance, layerMask))
        {
            m_isCameraBlock = true;
            Debug.DrawRay(m_objectToLookAt.position, vecteurdiff.normalized * hit.distance, Color.yellow);
            transform.SetPositionAndRotation(hit.point, transform.rotation);
        }

        else
        {
            m_isCameraBlock = false;
            Debug.DrawRay(m_objectToLookAt.position, vecteurdiff, Color.white);
        }
    }

    private float ClampAngle(float angle)
    {
        if (angle > 180)
        {
            angle -= 360;
        }
        return angle;
    }
}