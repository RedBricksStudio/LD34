using System;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public AudioClip meow;
    
    void OnCollisionEnter (Collision other) {
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "PickUp") {
			other.gameObject.SendMessage("grow");
			GetComponent<Transform>().SetParent(other.transform, true);
			gameObject.tag = "Player";
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<AudioSource>().PlayOneShot(meow);
 		}
	}
}