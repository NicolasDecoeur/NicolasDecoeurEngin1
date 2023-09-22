using UnityEngine;
public class CharacterFloorTrigger : MonoBehaviour
{
    public bool IsOnFloor { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        IsOnFloor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        IsOnFloor = false;
    }
}