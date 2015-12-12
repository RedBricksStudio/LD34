// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class EquipmentSlot : MonoBehaviour, I_EquipmentSlot
{

	[SerializeField]
	private I_InventoryItem equippedItem;

	public Transform displayHolderObject;
	private I_EquipmentSlotDisplay display;

	// Use this for initialization
	void Start ()
	{
		display = displayHolderObject.GetComponent<I_EquipmentSlotDisplay>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void setEquippedItem (I_InventoryItem i)
	{
		if (i != null) {
			equippedItem = i;
			display.changeDisplayingItem(equippedItem);
		}

		display.updateDisplay();
	}

	public I_InventoryItem getEquippedItem ()
	{
		return equippedItem;
	}
}

