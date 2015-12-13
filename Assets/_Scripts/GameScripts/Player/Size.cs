using System;
using UnityEngine;

public class Size : MonoBehaviour {
	// Attributes
	public GameObject secretWall;
	
	[SerializeField]
	private int size = 1;
	private int MAX_SIZE;

	private GameObject player;

	// Functions
	void Start() {
		MAX_SIZE = GameObject.FindGameObjectsWithTag("PickUp").Length;
		player = GameObject.Find("Player");
	}

	public void grow() {
		if(size < MAX_SIZE) {
			++size;
			player.SendMessage("slowDown");
			player.SendMessage("wardOffCamera");
		}
		else
			newVictoryCondition();
	}

	private void newVictoryCondition()  {
		secretWall.SetActive(false);
		Application.LoadLevel(3);
	}

}