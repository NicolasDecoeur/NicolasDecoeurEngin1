using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerSM : MonoBehaviour
{
    public Camera Camera { get; private set; }
    public Rigidbody RB { get; private set; }

    private CharacterState m_currentState;
    private List<CharacterState> m_possibleStates;
    [SerializeField] private CharacterFloorTrigger m_floorTrigger;

    [field:SerializeField] public float AccelerationValue { get; private set; }
    [field:SerializeField] public float MaxVelocity { get; private set; }
    [field:SerializeField] public float JumpItencity { get; private set; }

    private void Awake()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new FreeState());
        m_possibleStates.Add(new JumpState());
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
        Trytransition();
    }

    void FixedUpdate()
    {
        m_currentState.OnFixedUpdate();
    }
    private void Trytransition() 
    {
        m_currentState.OnUpdate();
        if (!m_currentState.CanExit())
        {
            return;
        }
        foreach (var state in m_possibleStates)
        {
            if (m_currentState == state)
            {
                continue;
            }
            if (state.CanEnter())
            {
                m_currentState.OnExit();
                m_currentState = state;
                m_currentState.OnEnter();
                return;
            }
        }
    }
    public bool IsInContactWithFloor()
    {
        return m_floorTrigger.IsOnFloor;
    }
}