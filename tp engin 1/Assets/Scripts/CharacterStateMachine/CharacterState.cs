
public class CharacterState : IState
{
    protected private CharacterControlerSM m_stateMachine;
    public virtual void OnStart(CharacterControlerSM stateMachine)
    {
        m_stateMachine = stateMachine;
    }

    public virtual void OnEnter()
    {
      
    }

    public virtual void OnExit()
    {
       
    }

    public virtual void OnFixedUpdate()
    {
       
    }

    public virtual void OnUpdate()
    {
       
    }
}
