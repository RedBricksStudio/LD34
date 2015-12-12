using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class FantasyManager : MonoBehaviour, I_ResourceManager {

	public GameObject displayGO;
	private I_ResourceDisplay display;
	
	public float maxFantasy;	
	private float fantasy;

	private float decreaseAmount;
	public float decreasingPercentage;
	
	// Use this for initialization
	void Start () {
		this.fantasy = maxFantasy;
		decreaseAmount = maxFantasy * (decreasingPercentage / 100.0f);

		display = displayGO.GetComponent<I_ResourceDisplay>();
		display.onDisplay(maxFantasy);
	}
	
	// We want to decrease the Fantasy
	// in regular intervals.
	void FixedUpdate () 
	{
		fantasy -= decreaseAmount;
		if (fantasy < 0.0f) { fantasy = 0.0f;}
		display.onDisplay(fantasy);
	}

	public void setMax (float amount)
	{
		maxFantasy = amount;
		decreaseAmount = maxFantasy * (decreasingPercentage / 100.0f);
	}

	public void setTo (float amount)
	{
		if (amount < maxFantasy) {
			fantasy = amount;
		} else {
			amount = maxFantasy;
		}
		
		display.onDisplay(fantasy);
	}

	public void increaseIn (float amount)
	{
		fantasy += amount;
		if (fantasy > maxFantasy){
			fantasy = maxFantasy;
		}
		
		display.onDisplay(fantasy);
	}
	
	public void decreaseIn (float amount)
	{
		fantasy -= amount;
		if (fantasy < 0.0f) {
			fantasy = 0.0f;
		}
		
		display.onDisplay(fantasy);
	}
	
	public float getCurValue ()
	{
		return fantasy;
	}
	
	public float getMaxValue ()
	{
		return maxFantasy;
	}
}
