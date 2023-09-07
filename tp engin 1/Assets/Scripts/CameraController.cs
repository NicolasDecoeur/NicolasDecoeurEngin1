using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_objectToLookAt;
    [SerializeField] private Transform m_camera;
    [SerializeField] private float m_rotationSpeed = 1.0f;
    [SerializeField] private Vector2 m_clampingXRotationValues = Vector2.zero;
    [SerializeField] private float m_closePointToObject = 3.92f;
    [SerializeField] private float m_farthestPointToObject = 10.0f;
    [SerializeField] private float m_cameraTarget;

    private float m_distance = 0.0f;

    // Update is called once per frame
    void Update()
    {
        UpdateHorizontalMovements();
        UpdateVerticalMovements();
        UpdateCameraScroll();
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
        m_distance = Vector3.Distance(m_objectToLookAt.position, m_camera.position);
        float scrollDelta = Input.mouseScrollDelta.y;

        if (scrollDelta != 0)
        {
            float newDistance = m_distance - scrollDelta;

            if (newDistance < m_closePointToObject || newDistance > m_farthestPointToObject)
            {
                Debug.Log("Trop proche ou trop loin de l'objet");
                return;
            }
            //TODO: Lerp plutôt que d'effectuer immédiatement la translation
            Vector3 direction = m_camera.position - m_objectToLookAt.position;
            m_camera.position = m_objectToLookAt.position + direction.normalized * newDistance;
        }
    }

    private void MoveCameraInFrontOfObstructionFUpdate()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;
       
        var vecteurdiff = transform.position - m_objectToLookAt.position;
        var distance = vecteurdiff.magnitude;
        if (Physics.Raycast(m_objectToLookAt.position, vecteurdiff, out hit, distance, layerMask))
        {
            Debug.DrawRay(m_objectToLookAt.position, vecteurdiff.normalized * hit.distance, Color.yellow);
            transform.SetPositionAndRotation(hit.point, transform.rotation);
        }
        else
        {
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