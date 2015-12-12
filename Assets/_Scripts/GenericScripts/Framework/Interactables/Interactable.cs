// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public abstract class Interactable : MonoBehaviour, I_Interactable
{
	protected bool interactable = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public abstract void onInteract (GameObject generator);
	
	public void onInteractableEnter ()
	{
		interactable = true;
	}

	public void onInteractableExit ()
	{
		interactable = false;
	}

	public bool isInteractable ()
	{
		return interactable;
	}

	//Collision detection
	public void OnTriggerEnter2D(Collider2D col) {
		if (col.tag.Equals("Player")) {
			onInteractableEnter();
		}
	}
	public void OnTriggerExit2D(Collider2D col) {
		if (col.tag.Equals("Player")) {
			onInteractableExit();
		}
	}
}

