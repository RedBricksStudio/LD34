
using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public interface I_Interactable
	{
		void onInteract(GameObject generator);

		void onInteractableEnter();

		void onInteractableExit();

		bool isInteractable();
	}
}

