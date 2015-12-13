using System;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "PickUp") {
			print("Player has collided with us");
			other.gameObject.SendMessage("grow");
			GetComponent<Transform>().SetParent(other.transform, true);
			gameObject.tag = "Player";
 		}
		else
			print("Collided with something else");
	}
}