using System;
using UnityEngine;

public class Size : MonoBehaviour {
	// Attributes
	[SerializeField]
	private int size = 1;
	[SerializeField]
	private int MAX_SIZE;
	public GameObject secretWall;

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