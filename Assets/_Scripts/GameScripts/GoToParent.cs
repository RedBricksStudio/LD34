using System;
using UnityEngine;

public class GoToParent : MonoBehaviour {
	Transform us;

	public void goToParent() {
		us = GetComponent<Transform>();
		us.position = Vector3.zero;
	}
}