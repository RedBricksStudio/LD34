using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    bool debug;
    [SerializeField]
    private float m_speedDelta = 150;
    [SerializeField]
    private float speedLoss = 30;

	private bool left;
	private bool iddle;
	private bool right;
	private bool front;
	private bool back;

    private Rigidbody m_rb;
    private Transform m_tr;

    private Vector3 m_velocity = new Vector3(0, 0, 0);
    private Animator anim;

	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_tr = GetComponent<Transform>();
        gameObject.tag = "Player";
		anim = gameObject.GetComponentInChildren<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
        m_velocity = new Vector3( Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        m_velocity = m_velocity.normalized * Time.deltaTime * m_speedDelta;


		print ("Hey this is for debug" + m_velocity.z);
        if((m_velocity.x == 0) && (m_velocity.z == 0) ){
			if (!iddle) {
				anim.SetTrigger ("iddle");
				iddle = true;
				left = false;
				right = false;
				front = false;
				back = false;
			}
        }

        else if(m_velocity.x > 0){
			if (!right) {
				anim.SetTrigger ("left");
				iddle = false;
				left = false;
				right = true;
				front = false;
				back = false;
			}
        }
        else if(m_velocity.x < 0){
			if (!left) {
				anim.SetTrigger ("left");
				iddle = false;
				left = true;
				right = false;
				front = false;
				back = false;
			}
        }
        else if(m_velocity.z < 0){
			if (!front) {
				anim.SetTrigger ("front");
				iddle = false;
				left = false;
				right = false;
				front = true;
				back = false;
			}
        }
        else if(m_velocity.z > 0){
			if (!back) {
				anim.SetTrigger ("back");
				iddle = false;
				left = false;
				right = false;
				front = false;
				back = true;
			}
        }

        m_rb.velocity = m_velocity;
	}

    public void slowDown() {
        m_speedDelta -= speedLoss;
    }

    public void wardOffCamera() {
        GameObject.Find("Camera").SendMessage("wardOff");
    }
}