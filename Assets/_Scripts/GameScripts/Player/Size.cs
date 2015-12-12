using System;
using UnityEngine;

public class Size : MonoBehaviour {
	// Attributes
	[SerializeField]
	private int size = 1;
	[SerializeField]
	private int MAX_SIZE = 8;
	
	private GameObject player;

	// Functions
	void Start() {
		player = GameObject.Find("Player");
	}

	public void grow() {
		if(size < MAX_SIZE)
			++size;

		player.SendMessage("slowDown");
		player.SendMessage("wardOffCamera");
	}

}