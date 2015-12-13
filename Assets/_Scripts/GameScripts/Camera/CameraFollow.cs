using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	private Transform camera;
	[SerializeField]
	private float cameraDistance = 10f;
	[SerializeField]
	private float cameraDistanceDelta = 1f;
	private int timesWarded = 0;

	void Start() {
		player = GameObject.Find("Player").GetComponent<Transform>();
		camera = GetComponent<Transform>();
	}
  
	void Update () {
    	camera.position = new Vector3 (player.position.x, player.position.y, player.position.z - cameraDistance - cameraDistanceDelta * timesWarded);
    }

    public void wardOff() {
    	++timesWarded;
    }
}