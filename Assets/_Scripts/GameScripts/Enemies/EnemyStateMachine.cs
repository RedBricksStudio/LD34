using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour {

    public bool debug;
    
    public enum EnemyStates
    {
        Idle, Patrol, Chasing, Attacking, LookAround
    }

    private EnemyStates m_state = EnemyStates.Idle;

    //Patrol Attributes
    private int m_currWaypoint = 0;
    public Transform[] waypoints;

    //Attributes
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_range;

    private Transform m_playerToChase;

    //Private Components
    Transform m_tr;
    Rigidbody m_rb;
    NavMeshAgent m_nva;

	// Use this forinitialization
	void Start () {
        m_tr = GetComponent<Transform>();
        m_rb = GetComponent<Rigidbody>();
        m_nva = GetComponent<NavMeshAgent>();

        ChangeState(EnemyStates.Patrol);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
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

        switch (m_state) 
        {
            case EnemyStates.Idle:
                handleIdleEntered();
                break;
            case EnemyStates.Patrol:
                handlePatrolEntered();
                break;
            case EnemyStates.Chasing:
                handleChasingEntered();
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
            //Debug.Log("Handling state" + m_state);

        switch (m_state)
        {
            case EnemyStates.Idle:
                handleIdle();
                break;
            case EnemyStates.Patrol:
                handlePatrol();
                break;
            case EnemyStates.Chasing:
                handleChasing();
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
            case EnemyStates.Chasing:
                handleChasingExit();
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
        if (debug)
            Debug.Log("handlePatrolEntered()");

        m_currWaypoint = 0;
        m_nva.destination = waypoints[m_currWaypoint].position;
    }

    private void handlePatrol()
    {
        /*
        if (debug)
            Debug.Log("handlePatrol()");  
         */
        
    }

    private bool waypointReached()
    {
        return (Mathf.Abs(m_tr.position.x - waypoints[m_currWaypoint].position.x) <= m_range
            || Mathf.Abs(m_tr.position.z - waypoints[m_currWaypoint].position.z) <= m_range);
    }

    private void handlePatrolExit()
    {
        if (debug)
            Debug.Log("handlePatrolExit()");
    }

    //Preparing
    private void handleChasingEntered()
    {
        if (debug)
            Debug.Log("handleChasingEntered()" + m_playerToChase.name);

        m_nva.destination = m_playerToChase.position;
    }

    private void handleChasing()
    {
        if (playerReached())
        {
            ChangeState(EnemyStates.Attacking);
        }
    }

    private bool playerReached()
    {
        return (m_tr.position - m_playerToChase.position).sqrMagnitude <= m_range;
    }

    private void handleChasingExit()
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


    //OTHER METHODS
    public void onPlayerSeen(Transform player)
    {
        if (m_state.Equals(EnemyStates.LookAround) ||
            m_state.Equals(EnemyStates.Patrol) ||
            m_state.Equals(EnemyStates.Idle))
        {
            m_playerToChase = player;
            ChangeState(EnemyStates.Chasing);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision" + col.name + col.tag);

        if (col.tag.Equals("waypoint") && m_state.Equals(EnemyStates.Patrol) &&
            col.transform.position == waypoints[m_currWaypoint].position)
        {

            Debug.Log("Waypoint reached");

            m_currWaypoint = (m_currWaypoint + 1) % waypoints.GetLength(0);
            m_nva.destination = waypoints[m_currWaypoint].position;
        }
    }

}
