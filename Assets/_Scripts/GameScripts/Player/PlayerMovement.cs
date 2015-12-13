using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class PlayerMovement : MonoBehaviour {

    bool debug;
    [SerializeField]
    private float m_speedDelta = 150;
    [SerializeField]
    private float speedLoss = 30;

    private Rigidbody m_rb;
    private Transform m_tr;

    private Vector3 m_velocity = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_tr = GetComponent<Transform>();
        gameObject.tag = "Player";
	}
	
	// Update is called once per frame
	void Update () {
        m_velocity = new Vector3( Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_velocity = m_velocity.normalized * Time.deltaTime * m_speedDelta;

        m_rb.velocity = m_velocity;
	}

    public void slowDown() {
        m_speedDelta -= speedLoss;
        print("New Player top speed is: " + m_speedDelta);
    }

    public void wardOffCamera() {
        GameObject.Find("Camera").SendMessage("wardOff");
    }
}