// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System.Collections.Generic;

public class PlayerScrollBookHolder : MonoBehaviour, I_ScrollBookHolder
{
	[SerializeField]
	private Transform displayHolderObject;
	private I_ScrollBookDisplay display;

	private List<ScrollText> scrolls;

	// Use this for initialization
	void Awake ()
	{
		scrolls = new List<ScrollText>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void addScroll (ScrollText text) {
		scrolls.Add(text);
	}
}

