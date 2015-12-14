using UnityEngine;
using System.Collections;

public class MoveToBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingLayerName = "Walls";
        GetComponent<Renderer>().sortingLayerID = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
