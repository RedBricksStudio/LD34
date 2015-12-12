using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class HealthManager : MonoBehaviour, I_ResourceManager, I_Damageable {

	public GameObject display;
	private I_ResourceDisplay healthDisplay;

	public float maxHealth;

	private float health;

	// Use this for initialization
	void Start () {
		this.health = maxHealth;
		healthDisplay = display.GetComponent<I_ResourceDisplay>();
		healthDisplay.onDisplay(maxHealth);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void setMax (float amount)
	{
		this.health = amount;
	}

	public void setTo (float amount)
	{
		if (amount < maxHealth) {
			health = amount;
		} else {
			amount = maxHealth;
		}

		healthDisplay.onDisplay(health);
	}

	public void increaseIn (float amount)
	{
		health += amount;
		if (health > maxHealth){
			health = maxHealth;
		}

		healthDisplay.onDisplay(health);
	}

	public void decreaseIn (float amount)
	{
		health -= amount;
		if (health <= 0) {
			health = 0;
			onDeath();
		}

		healthDisplay.onDisplay(health);
	}

	public float getCurValue ()
	{
		return health;
	}

	public float getMaxValue ()
	{
		return maxHealth;
	}

	public void onDamage (float amount)
	{
		this.decreaseIn(amount);
	}

	void onDeath ()
	{
		Destroy (gameObject);
	}
}
