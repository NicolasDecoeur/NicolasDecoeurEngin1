public abstract class CharacterState : IState
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

    public virtual bool CanEnter()
    {
        return true;
    }

    public virtual bool CanExit()
    {
        return true;
    }
}