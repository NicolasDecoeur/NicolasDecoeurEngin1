using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerSM : MonoBehaviour
{
    public Camera Camera{ get; private set; }
    public Rigidbody RB { get; private set; }

    private CharacterState m_currentState;
    private List<CharacterState> m_possibleStates;

    [field:SerializeField] public float AccelerationValue { get; private set; }
    [field: SerializeField] public float MaxVelocity { get; private set; }

    private void Awake()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new FreeState());
    }

    void Start()
    {
        Camera = Camera.main;
        RB = GetComponent<Rigidbody>();

        foreach (CharacterState state in m_possibleStates)
        {
            state.OnStart(this);
        }
        m_currentState = m_possibleStates[0];
        m_currentState.OnEnter();
    }
    void Update()
    {
        m_currentState.OnUpdate();
    }

    void FixedUpdate()
    {
        m_currentState.OnFixedUpdate();
    }
}