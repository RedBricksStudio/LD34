using UnityEngine;
using System.Collections;

public class SpriteLookAtCamera : MonoBehaviour {

    Transform camera;

    Transform m_tr;

	// Use this for initialization
	void Start () {
        camera = GameObject.Find("Camera").GetComponent<Transform>();
        m_tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        m_tr.LookAt(camera.position);
	}
}
