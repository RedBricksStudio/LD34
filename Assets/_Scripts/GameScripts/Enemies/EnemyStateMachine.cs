using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour {

    public bool debug;
    
    public enum EnemyStates {
        Idle, Patrol, Chasing, Attacking, LookAround
    }

    private EnemyStates m_state = EnemyStates.Idle;

    //Patrol Attributes
    private int m_currWaypoint = 0;
    public Transform[] waypoints;

    private bool[] m_directionsToLookAt = new bool[4];
    private bool m_waypointReached = false;
    private Vector3 m_nva_velocity;
    private bool m_lookingAround = false;

    //Attributes
    [SerializeField]
    private float m_speed;
    [SerializeField]
    private float m_range;
    [SerializeField]
    private float m_sight;
    [SerializeField]
    private bool m_lookAroundInWaypoints;

    private Vector3 m_direction;

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
        if (!m_lookingAround)
        {
            if (Mathf.Abs(m_nva.velocity.x) - Mathf.Abs(m_nva.velocity.z) > 0)
            {
                if (m_nva.velocity.x > 0)
                {
                    m_direction.x = 1;
                }
                else
                {
                    m_direction.x = -1;
                }
                m_direction.z = 0;
            }
            else
            {
                if (m_nva.velocity.z > 0)
                {
                    m_direction.z = 1;
                }
                else
                {
                    m_direction.z = -1;
                }
                m_direction.x = 0;
            }
        }

        //Change Animation
        //m_anim.sendSpeedX();
        //m_anim.sendSpeedY();

        if (debug)
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.DrawRay(m_tr.position, rotateVector(m_direction, (35 - (i * 20))) * m_sight, Color.Lerp(Color.green, Color.cyan, i * 4));
            }

        }
                
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
            //Debug.Log("handlePatrolEntered()");

        
        m_nva.destination = waypoints[m_currWaypoint].position;
        m_nva.velocity = m_nva_velocity;
        m_nva.Resume();
    }

    private void handlePatrol()
    {
        
        if (debug)
        //    Debug.Log("handlePatrol()");

        if (playerDetected()) {
            ChangeState(EnemyStates.Chasing);
        }

    }   

    private void handlePatrolExit()
    {
        if (debug)
            Debug.Log("handlePatrolExit()");
    }

    //Preparing
    private void handleChasingEntered() {
        if (debug)
            Debug.Log("handleChasingEntered()" + m_playerToChase.name);

        m_nva.destination = m_playerToChase.position;
    }

    private void handleChasing() {
        if (playerReached()) {
            if(debug)
                print("<color=red>Enemy " + gameObject.name + "has reached the player </color>");
            ChangeState(EnemyStates.Attacking);
        }
    }

    private bool playerReached() {
        return (m_tr.position - m_playerToChase.position).sqrMagnitude <= m_range;
    }

    private void handleChasingExit() {        
        m_nva.velocity = Vector3.zero;
        m_nva.Stop();
    }

    //LookAround
    private void handleLookAroundEntered() {
        m_nva_velocity = m_nva.velocity;
        m_nva.velocity = Vector3.zero;
        Debug.Log("handleLookAroundEntered()");
        //Check which walls are in sight
        RaycastHit hit;
        for (int i = 0; i < 4; i++) {
            if (Physics.Raycast(m_tr.position, rotateVector(m_direction, i * 90), out hit, m_range)) {
                //if (hit.collider.tag.Equals("wall"))
                {
                    Debug.Log("Added Direction " + i*90);
                    m_directionsToLookAt[i] = true;
                }
            }
        }
        Debug.Log(m_directionsToLookAt);
    }

    private void handleLookAround() {
        //Debug.Log("handleLookAround()");

        //Look around with coroutines
        if (!m_lookingAround)
        {
            m_lookingAround = true;
            StartCoroutine(lookAround());
        }
        
    }

    private IEnumerator lookAround() {
        m_nva.Stop();
        bool detected = false;
        for (int i = 0; i < 4 && !detected; i++)
        {
            //if (m_directionsToLookAt[i])
            //{
            Debug.Log("Detecting Player in Dir" + m_direction + detected);
            if (playerDetected())
            {
                detected = true;
                Debug.Log("Player Detected!" + m_direction);
                onPlayerSeen();
            }            
            //}
            if (!detected)
            {
                yield return new WaitForSeconds(2);
            }
            m_direction = rotateVector(m_direction, 90);
        }
        m_nva.Resume();
        m_lookingAround = false;
        //Exit state
        if (!detected) {
            ChangeState(EnemyStates.Patrol);
        }
    }

    

    private void handleLookAroundExit() {
        for (int i = 0; i < 4; i++) {
            m_directionsToLookAt[i] = false;
        }
    }

    //Attacking
    private void handleAttackingEntered() {
        //Play attacking animation
    }

    private void handleAttacking() {
        Application.LoadLevel(2);
        //Destroy Scene and go to Game Over
    }

    private void handleAttackingExit() {
        throw new System.NotImplementedException();
    }


    //OTHER METHODS
    public void onPlayerSeen() {
        if (m_state.Equals(EnemyStates.LookAround) ||
            m_state.Equals(EnemyStates.Patrol) ||
            m_state.Equals(EnemyStates.Idle)) {            
            ChangeState(EnemyStates.Chasing);
        }
    }

    void OnTriggerEnter(Collider col) {       

        if (col.tag.Equals("waypoint") && m_state.Equals(EnemyStates.Patrol) &&
            col.transform.position == waypoints[m_currWaypoint].position && !m_waypointReached) {
            m_currWaypoint = (m_currWaypoint + 1) % waypoints.GetLength(0);
            m_nva.destination = waypoints[m_currWaypoint].position;
            m_waypointReached = true;
            if (m_lookAroundInWaypoints) {
                ChangeState(EnemyStates.LookAround);
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag.Equals("waypoint") && m_waypointReached &&
            col.transform.position == waypoints[m_currWaypoint].position)
        {
            m_waypointReached = false;
        }
    }

    private Vector3 rotateVector(Vector3 m_direction, int p)
    {
        return Quaternion.AngleAxis(p, Vector3.up) * m_direction;
    }
        

    private bool playerDetected()
    {
        RaycastHit hit;
        bool detected = false;

        //Detect player 
        int i = 0;
        while (i < 5 && !detected)
        {
            if (Physics.Raycast(m_tr.position, rotateVector(m_direction, 35 - (i * 20)), out hit, m_sight))
            {
                //Debug.Log(hit.collider.name);

                if (hit.collider.tag.Equals("Player"))
                {
                    detected = true;

                    m_playerToChase = hit.collider.transform;

                    if (debug)
                        Debug.Log("Player Detected");
                }

            }
            i++;
        }
        return detected;
    }    
}
