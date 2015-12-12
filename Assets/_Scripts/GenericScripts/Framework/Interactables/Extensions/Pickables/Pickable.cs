// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public abstract class Pickable : Interactable, I_Pickable {
	public Transform itemHolderObject;	
	private I_InventoryItem item;

	public Transform hintHolderObject;
	private I_InteractableHint hint;

	private Collider2D myCollider;
	private bool pickable = false;

	// Use this for initialization
	void Awake () {
		this.myCollider = GetComponent<Collider2D>();
		item = itemHolderObject.GetComponent<I_InventoryItem>();
		hint = hintHolderObject.GetComponent<I_InteractableHint>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void onInteract (GameObject generator) {
		onPickUp(generator);
	}

    
	public void onInteractableEnter () {
		hint.onShowHint();
		pickable = true;
	}

	public void onInteractableExit () {
		hint.onHideHint();
		pickable = false;
	}

	public bool isInteractable () {
		return interactable;
	}

	public abstract void onPickUp(GameObject generator);

	//Abstract methods to be implemented by each particular class
	public abstract bool canBePicked();
}