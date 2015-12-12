using System;
using UnityEngine;
using AssemblyCSharp;

public class PowerUp : Pickable {
	public bool canBePicked() {
		print("I'm being picked");
		return true;
	}
}