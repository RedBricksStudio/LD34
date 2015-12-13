using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	void Update() {
		if(Input.GetButton("Submit"))
			Application.LoadLevel(0);
	}
	public void test() {
		Application.LoadLevel(0);
	}
}