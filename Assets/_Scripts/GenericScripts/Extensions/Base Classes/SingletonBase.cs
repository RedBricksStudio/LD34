// /*
//  * @author Borja Lorente Escobar
//  * Copyright 2015
//  */
using System;
using UnityEngine;


namespace AssemblyCSharp
{
	public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T instance;

		public static T Instance
		{
			get
			{
				if (instance == null)
				{
					//Find an instance of the obhect anywhere in the scene.
					instance = (T) FindObjectOfType (typeof(T));

					if (instance == null)
					{
						Debug.Log ("An instance of " + (typeof(T)) + " is needed in the scene");
					}
				}
				return instance;
			}
		}

	}
}

