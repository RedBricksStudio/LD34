using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	void Update() {
		if(Input.GetButton("Submit"))
			Application.LoadLevel("Game");
	}
	public void test() {
		Application.LoadLevel("Game");
	}
}