using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour {

    enum EnemyStates
    {
        Patrol, Preparing, Attacking, LookAround
    }

    private EnemyStates m_state;

	// Use this forinitialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeState(EnemyStates newState)
    {
        onStateExit(m_state);
        m_state = newState;
        onStateEnter(m_state);
    }

    private void onStateEnter(EnemyStates m_state)
    {
        
    }

    private void onStateExit(EnemyStates m_state)
    {
        throw new System.NotImplementedException();
    }
}
