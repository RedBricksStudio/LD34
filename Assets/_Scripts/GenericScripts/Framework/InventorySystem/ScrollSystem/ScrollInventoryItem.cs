// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;


public class ScrollInventoryItem : MonoBehaviour, I_InventoryItem
{
	public Transform scrollBookHolderObject;
	private I_ScrollBookHolder scrollBookHolder;

	[SerializeField]
	private TextAsset rawText;

	private ScrollText textObject;

	// Use this for initialization
	void Awake ()
	{
		if (scrollBookHolder != null) {
			scrollBookHolder = scrollBookHolderObject.GetComponent<I_ScrollBookHolder>();
		}
		textObject = new ScrollText(rawText);
		Debug.Log("Text Loaded!");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public string getName ()
	{
		return textObject.getName();
	}

	public int getId ()
	{
		return -1;
	}

	public E_InventoryItemTypes getType ()
	{
		return E_InventoryItemTypes.ScrollText;
	}

	public bool isEquipable ()
	{
		return false;
	}

	public bool isUsable ()
	{
		return false;
	}

	public bool isViewable ()
	{
		return true;
	}

	public void onDoEffect (GameObject user)
	{
		scrollBookHolder.addScroll(textObject);
	}
}

