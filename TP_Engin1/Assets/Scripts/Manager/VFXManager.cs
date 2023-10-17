using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager _Instance
    {
        get;
        protected set;
    }

    [SerializeField]
    private GameObject m_hitPS;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
    }

    public void InstantiateVFX(EVFX_TYPE vFxType, Vector3 pos)
    {
        switch (vFxType)
        {
            case EVFX_TYPE.Hit:
                Instantiate(m_hitPS, pos, Quaternion.identity, transform);
                
                break;

            default:
                break;
        }
    }
}

public enum EVFX_TYPE
{
    Hit,
    Count
}