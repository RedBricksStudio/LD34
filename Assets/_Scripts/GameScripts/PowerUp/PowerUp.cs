using System;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.name == "Player") {
			print("Player has collided with us");
			other.gameObject.SendMessage("grow");
			Destroy(gameObject);
		}
		else
			print("Collided with something else");
	}
}