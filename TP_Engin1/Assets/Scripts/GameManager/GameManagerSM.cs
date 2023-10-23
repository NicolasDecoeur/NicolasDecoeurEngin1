using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManagerSM : BaseStateMachine<IState>
{
    //public static GameManagerSM _Instance
    //{
    //    get;
    //    protected set;
    //}

    [SerializeField]
    protected Camera m_gameplayCamera;
    [SerializeField]
    protected Camera m_cinematicCamera;

    //protected override void Awake()
    //{
    //   if (_Instance == null)
    //   {
    //       _Instance = this;
    //       DontDestroyOnLoad(this);
    //   }
    //   else if (_Instance != this)
    //   {
    //       Destroy(gameObject);
    //   }
    //}

    protected override void CreatePossibleStates()
    {
        m_possibleStates = new List<IState>();
        m_possibleStates.Add(new GameplayState(m_gameplayCamera));
        m_possibleStates.Add(new CinematicState(m_cinematicCamera));
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}