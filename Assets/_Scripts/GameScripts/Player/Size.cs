using System;
using UnityEngine;

public class Size : MonoBehaviour {
	// Attributes
	[SerializeField]
	private int size = 0;
	[SerializeField]
	private int MAX_SIZE = 8;

	public Transform playerMovement;

	// Functions
	void Start() {
	}

	void Update() {
	}

	public void grow() {
		++size;

		playerMovement.gameObject.SendMessage("slowDown");
		playerMovement.gameObject.SendMessage("wardOffCamera");
	}

}