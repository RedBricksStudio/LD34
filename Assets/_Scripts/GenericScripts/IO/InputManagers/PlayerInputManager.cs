using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;
using System;

public class PlayerInputManager : MonoBehaviour, I_InputSender {

	private List<I_InputReceiver> receivers = new List<I_InputReceiver> ();

	void Start() {

	}
	
	// Update is called once per frame (irregular)
	void Update () {
		//Iterate trough all the possible keys of E_InputTypes, 
		//And notify whenever any one is pressed or released
		foreach (E_InputTypes it in Enum.GetValues(typeof(E_InputTypes))) {
			if (Input.GetButtonDown(it.ToString())) {
				foreach (I_InputReceiver ir in receivers) {
					ir.onButtonPressed(it);
				}
			}

			if (Input.GetButtonUp(it.ToString())) {
				foreach (I_InputReceiver ir in receivers) {
					ir.onButtonReleased(it);
				}
			}
		}

	}

	public void addInputReceiver (I_InputReceiver ir)
	{
		this.receivers.Add (ir);
		ir.onAttachedToSender ();
	}

	public void removeInputReceiver (I_InputReceiver ir)
	{
		this.receivers.Remove (ir);
		ir.onDetachFromSender ();
	}

}
