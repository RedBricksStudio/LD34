
// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Activator : Interactable
{
	[SerializeField]
	private Transform activableHolder;
	private I_Activable activable;

	// Use this for initialization
	void Start ()
	{
		activable = activableHolder.GetComponent<I_Activable>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	public override void onInteract (GameObject generator)
	{
		if (activable.canBeActivated()) {
			activable.onActivate(generator);
		}
	}


}

