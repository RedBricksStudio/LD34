using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerMovement : MonoBehaviour, I_InputReceiver {

    bool debug;
    public Transform inputSender;

    [SerializeField]
    private float m_speedDelta = 10;
    [SerializeField]
    private float speedLoss = 1;

    private Rigidbody m_rb;
    private Transform m_tr;

    private Vector3 m_velocity = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        inputSender.GetComponent<I_InputSender>().addInputReceiver(this);
        m_rb = GetComponent<Rigidbody>();
        m_tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_rb.velocity = m_velocity;

        m_tr.up = m_rb.velocity;
	}

    public void onAttachedToSender() {
        if (debug)
            Debug.Log("Attached to sender");
    }

    public void onDetachFromSender() {
        if (debug)
            Debug.Log("Detached from sender");
    }

    public void onButtonPressed(E_InputTypes type) {
        switch (type) {
            case E_InputTypes.Up:
                m_velocity.y = m_speedDelta;
                break;
            case E_InputTypes.Down:
                m_velocity.y = -m_speedDelta;
                break;
            case E_InputTypes.Left:
                m_velocity.x = -m_speedDelta;
                break;
            case E_InputTypes.Right:
                m_velocity.x = m_speedDelta;
                break;
        }
    }

    public void onButtonReleased(E_InputTypes type) {
        switch (type) {
            case E_InputTypes.Up:
                if(Input.GetButton("Down"))
                    m_velocity.y = -m_speedDelta;
                else
                    m_velocity.y = 0;
            break;
            case E_InputTypes.Down:
                if(Input.GetButton("Up"))
                    m_velocity.y = m_speedDelta;
                else
                    m_velocity.y = 0;
            break;
            case E_InputTypes.Left:
                if(Input.GetButton("Right"))
                    m_velocity.x = m_speedDelta;
                else
                    m_velocity.x = 0;
            break;
            case E_InputTypes.Right:
                if(Input.GetButton("Left"))
                    m_velocity.x = -m_speedDelta;
                else
                    m_velocity.x = 0;
            break;
        }
    }

    public void slowDown() {
        m_speedDelta -= speedLoss;
        print("New Player top speed is: " + m_speedDelta);
    }

    public void wardOffCamera() {
        GameObject.Find("Camera").SendMessage("wardOff");
    }
}