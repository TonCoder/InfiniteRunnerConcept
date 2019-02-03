using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private float followSpeed;
	[SerializeField] private GameObject player;
	[SerializeField] private float CameraDistance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		CameraDistance = Camera.main.fieldOfView;
	}

	void ChangeCameraDistance () {
		Camera.main.fieldOfView = CameraDistance;
	}

	// Update is called once per frame
	void Update () {
		float newXPos = Mathf.Lerp (transform.position.x, player.transform.position.x, followSpeed * Time.deltaTime);
		transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);

		ChangeCameraDistance ();
	}
}