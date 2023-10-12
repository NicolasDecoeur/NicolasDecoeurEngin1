using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_hitBox;

    public void ActivateHitBox()
    {
        m_hitBox.SetActive(true);
    }

    public void DisableHitBox()
    {
        m_hitBox.SetActive(false);
    }
}