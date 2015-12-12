// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */

using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public interface I_Pickable : I_Interactable
	{
		void onPickUp(GameObject generator);
		bool canBePicked();
	}
}

