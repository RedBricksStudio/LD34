using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MovingProperties : MonoBehaviour, I_MovingProperties {

	[SerializeField]
	private float speedRight = 100;
	[SerializeField]
	private float speedLeft = 100;
	[SerializeField]
	private float forceUp = 100;
	[SerializeField]
	private bool canCrouch = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getSpeedRight ()
	{
		return speedRight;
	}

	public float getSpeedLeft ()
	{
		return speedLeft;
	}

	public float getForceUp ()
	{
		return forceUp;
	}

	public bool canItCrouch ()
	{
		return canCrouch;
	}
}
