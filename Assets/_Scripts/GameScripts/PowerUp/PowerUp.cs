using System;
using UnityEngine;
using AssemblyCSharp;

public class PowerUp : Pickable {
	public override bool canBePicked() {
		return true;
	}

	public override void onPickUp(GameObject generator) {
			Size s = generator.GetComponent<Size>();
			s.grow();
	}
}