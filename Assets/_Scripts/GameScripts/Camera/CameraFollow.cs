using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Transform player;
	private Transform camera;
	[SerializeField]
	private float cameraDistance = 10f;
	[SerializeField]
	private float cameraDistanceDelta = 1f;
	[SerializeField]
	private float inclination = 0.872665f;
	private float realAngle;
	private float adjacent;
	private float opposite;

	void Start() {
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		camera = GetComponent<Transform>();
		realAngle = ((.5f * Mathf.PI) - (inclination));
		camera.eulerAngles = new Vector3(inclination * Mathf.Rad2Deg, 0f, 0f);
		realAngle = inclination;
		gameObject.tag = "MainCamera";
	}
  
	void Update () {
		adjacent = Mathf.Cos(realAngle) * cameraDistance;
		opposite = Mathf.Tan(realAngle) * adjacent;
    	camera.position = new Vector3(player.position.x, (player.position.y + opposite), player.position.z  - adjacent);
    	// This rotates all the sprites to look at the camera
		GameObject[] sprites = GameObject.FindGameObjectsWithTag("Sprite");
		foreach(GameObject sprite in sprites) {
			sprite.transform.LookAt(camera);
		}
    }

    public void wardOff() {
    	cameraDistance += cameraDistanceDelta;
    }
}