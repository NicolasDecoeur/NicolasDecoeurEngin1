using UnityEngine;

public class CharacterFloorTrigger : MonoBehaviour
{
    public bool IsOnFloor { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("on touche le sol");
        IsOnFloor = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("on touche pas le sol");
        IsOnFloor = false;
    }
}