using UnityEngine;
public class StuntZone : MonoBehaviour
{
    public bool IsOnStuntZone { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        IsOnStuntZone = true;
        Debug.Log("ont est sur la zone");
    }
    private void OnTriggerExit(Collider other)
    {
        IsOnStuntZone = false;
        Debug.Log("ont est pas sur la zone");
    }
}