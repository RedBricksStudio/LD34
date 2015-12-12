using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour {

    public bool debug;
    
    public enum EnemyStates
    {
        Idle, Patrol, Preparing, Attacking, LookAround
    }

    private EnemyStates m_state = EnemyStates.Idle;

    //Patrol Attributes
    private int m_currWaypoint = 0;
    public Transform[] waypoints;


    //Private Components
    Transform m_tr;
    Rigidbody2D m_rb;

	// Use this forinitialization
	void Start () {
        m_tr = GetComponent<Transform>();
        m_rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        onState(m_state);
	}    

    public void ChangeState(EnemyStates newState)
    {
        onStateExit(m_state);
        m_state = newState;
        onStateEnter(m_state);
    }

    private void onStateEnter(EnemyStates m_state)
    {
        if (debug)
            Debug.Log("Entering state" + m_state);

        switch (m_state) {
            case EnemyStates.Idle:
                handleIdleEntered();
                break;
            case EnemyStates.Patrol:
                handlePatrolEntered();
                break;
            case EnemyStates.Preparing:
                handlePreparingEntered();
                break;
            case EnemyStates.LookAround:
                handleLookAroundEntered();
                break;
            case EnemyStates.Attacking:
                handleAttackingEntered();
                break;
        }
                
    }
    
    private void onState(EnemyStates m_state)
    {
        if (debug)
            Debug.Log("Handling state" + m_state);

        switch (m_state)
        {
            case EnemyStates.Idle:
                handleIdle();
                break;
            case EnemyStates.Patrol:
                handlePatrol();
                break;
            case EnemyStates.Preparing:
                handlePreparing();
                break;
            case EnemyStates.LookAround:
                handleLookAround();
                break;
            case EnemyStates.Attacking:
                handleAttacking();
                break;
        }
    }    

    private void onStateExit(EnemyStates m_state)
    {
        if (debug)
            Debug.Log("Exiting state" + m_state);

        switch (m_state)
        {
            case EnemyStates.Idle:
                handleIdleExit();
                break;
            case EnemyStates.Patrol:
                handlePatrolExit();
                break;
            case EnemyStates.Preparing:
                handlePreparingExit();
                break;
            case EnemyStates.LookAround:
                handleLookAroundExit();
                break;
            case EnemyStates.Attacking:
                handleAttackingExit();
                break;
        }

    }    

    //Idle
    private void handleIdleEntered()
    {
        
    }

    private void handleIdle()
    {
        
    }

    private void handleIdleExit()
    {
        
    }

    //Patrol
    private void handlePatrolEntered()
    {
        m_currWaypoint = 0;
    }

    private void handlePatrol()
    {
        
    }

    private void handlePatrolExit()
    {
        throw new System.NotImplementedException();
    }

    //Preparing
    private void handlePreparingEntered()
    {
        throw new System.NotImplementedException();
    }

    private void handlePreparing()
    {
        throw new System.NotImplementedException();
    }

    private void handlePreparingExit()
    {
        throw new System.NotImplementedException();
    }

    //LookAround
    private void handleLookAroundEntered()
    {
        throw new System.NotImplementedException();
    }

    private void handleLookAround()
    {
        throw new System.NotImplementedException();
    }

    private void handleLookAroundExit()
    {
        throw new System.NotImplementedException();
    }

    //Attacking
    private void handleAttackingEntered()
    {
        throw new System.NotImplementedException();
    }

    private void handleAttacking()
    {
        throw new System.NotImplementedException();
    }

    private void handleAttackingExit()
    {
        throw new System.NotImplementedException();
    }



}
