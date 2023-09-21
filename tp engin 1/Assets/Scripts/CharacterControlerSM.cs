using System.Collections.Generic;
using UnityEngine;

public class CharacterControlerSM : MonoBehaviour
{
    public Camera Camera { get; private set; }

    private CharacterState m_currentState;
    private List<CharacterState> m_possibleStates;
    [SerializeField] private CharacterFloorTrigger m_floorTrigger;
   
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody RB { get; private set; }
    [field: SerializeField] public float m_fowardSpeed { get; private set; }
    [field: SerializeField] public float m_sidewaySpeed { get; private set; }
    [field: SerializeField] public float m_backwardSpeed { get; private set; }
    [field:SerializeField] public float AccelerationFowardValue { get; private set; }
    [field:SerializeField] public float AccelerationSideValue { get; private set; }
    [field:SerializeField] public float MaxVelocity { get; private set; }
    [field:SerializeField] public float JumpItencity { get; private set; }

    private void Awake()
    {
        m_possibleStates = new List<CharacterState>();
        m_possibleStates.Add(new FreeState());
        m_possibleStates.Add(new JumpState());
        m_possibleStates.Add(new HitState());
    }

    void Start()
    {
        Camera = Camera.main;

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
            if (state.CanEnter(m_currentState))
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

    public void UpdateAnimatorValues(Vector2 movementVecValue)
    {
        //Aller chercher ma vitesse actuelle
        //Communiquer directement avec mon Animator
        movementVecValue = new Vector2(movementVecValue.x, movementVecValue.y / MaxVelocity);

        Animator.SetFloat("MoveX", movementVecValue.x);
        Animator.SetFloat("MoveY", movementVecValue.y);
    }

    public void UpdateAnimatorJump()
    {
        Animator.SetTrigger("Jump");
    }

    public void UpdateAnimatorHit()
    {
        Animator.SetBool("Hit",true);
    }
}