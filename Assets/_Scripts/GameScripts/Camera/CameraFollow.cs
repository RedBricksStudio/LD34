using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private GameObject player;
	private Transform camera;
	[SerializeField]
	private float cameraDistance = 10f;
	[SerializeField]
	private float cameraDistanceDelta = 1f;

	void Start() {
		player = GameObject.Find("Player");
		camera = GetComponent<Transform>();
	}
  
	void Update () {
		Transform tPlayer = player.GetComponent<Transform>();
    	camera.position = new Vector3 (tPlayer.position.x, tPlayer.position.y, tPlayer.position.z - cameraDistance);
    }

    public void wardOff() {
    	camera.position = new Vector3 (camera.position.x, camera.position.y, camera.position.z - cameraDistanceDelta);
    }
}