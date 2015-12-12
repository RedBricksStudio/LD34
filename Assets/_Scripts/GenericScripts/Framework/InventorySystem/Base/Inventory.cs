// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

public class Inventory : MonoBehaviour, I_ReadOnlyInventory
{
	//The content of the Inventory
	public List<I_InventoryItem> Contents; 

	//The maximum number of items the Player can carry.
	public int MaxContent = 8; 

	//If this is turned on the Inventory script will output the base of what it's doing to the Console window.
	public bool DebugMode = false; 
	
	//Keep track of the InventoryDisplay script.
	public Transform displayHolderObject;
	private I_InventoryDisplay playersInvDisplay; 

	//The object the unactive items are going to be parented to. 
	//In most cases this is going to be the Inventory object itself.
	public Transform itemHolderObject; 
		
	//Handle components and assign the itemHolderObject.
	void Awake (){
		itemHolderObject = gameObject.transform;
		Contents = new List<I_InventoryItem>();
		
		playersInvDisplay = displayHolderObject.GetComponent<I_InventoryDisplay>();
		if (playersInvDisplay == null)
		{
			Debug.LogError("No Inventory Display script was found on " + transform.name + " but an Inventory script was.");
			Debug.LogError("Unless a Inventory Display script is added the Inventory won't show. Add it to the same gameobject as the Inventory for maximum performance");
		}
	}
	
	//Add an item to the inventory.
	public void AddItem ( I_InventoryItem Item  ){

		Contents.Add (Item);

		// Replace the old array with the new one
		// NOTE: As the old script's 'newContents' array only contained the item being picked up,
		// it was only able to copy that item
		if (DebugMode)
		{
			Debug.Log(Item.getName()+" has been added to inventroy");
			Debug.Log ("The Inventory contains " + Contents.Count + " items");
		}		

	}
	
	//Removed an item from the inventory (IT DOESN'T DROP IT).
	public void RemoveItem ( I_InventoryItem Item  )
	{
		ArrayList newContents = new ArrayList(Contents);


		int index = 0;
		bool shouldend = false;
		foreach(I_InventoryItem i in newContents) //Loop through the Items in the Inventory:
		{
			if(i == Item) //When a match is found, remove the Item.
			{
				newContents.RemoveAt(index);
				shouldend=true;
				//No need to continue running through the loop since we found our item.
			}
			index++;
			
			if(shouldend) //Exit the loop
			{
				//Contents=newContents.ToBuiltin(Transform); //!!!!//
				//Contents=newContents.ToArray(typeof (Transform)) as Transform[];
				if (DebugMode)
				{
					Debug.Log(Item.getName()+" has been removed from inventroy");
				}
				return;
			}
		}
	}
	
	//Dropping an Item from the Inventory
	public void DropItem (I_InventoryItem item){

		if (DebugMode)
		{
			Debug.Log(item.getName() + " has been dropped");
		}
	}
	
	//This will tell you everything that is in the inventory.
	void DebugInfo (){
		Debug.Log("Inventory Debug - Contents");
		int items=0;
		foreach(I_InventoryItem i in Contents){
			items++;
			// Debug.Log(i.name);
		}
		Debug.Log("Inventory contains "+items+" Item(s)");
	}

	public void displayInventory() {
		playersInvDisplay.onDisplay(Contents);
	}

}

