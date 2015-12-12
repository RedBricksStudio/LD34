// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */

using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public interface I_InventoryItem
	{
		//Get Relevant info
		string getName();
		int getId();
		E_InventoryItemTypes getType();

		//Get type of object
		bool isEquipable();
		bool isUsable();
		bool isViewable();

		void onDoEffect(GameObject user);
	}
}

