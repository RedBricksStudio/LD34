using System;
using UnityEngine;
using AssemblyCSharp;

public class PowerUp : Pickable {
	public override bool canBePicked() {
		print("I'm being picked");
		return true;
	}

	public override void onPickUp(GameObject generator) {
			Size s = generator.GetComponent<Size>();
			s.grow();
	}
}