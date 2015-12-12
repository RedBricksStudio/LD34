using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MouseTracker : MonoBehaviour {

	private Transform tr;
	
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		tr.SetX (point.x);
		tr.SetY (point.y);
	}
}
