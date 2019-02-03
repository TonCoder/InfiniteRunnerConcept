using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveForward : MonoBehaviour {

	[SerializeField] private float speed = 10;
	[SerializeField] private float despawnTimer = 2;

	private void OnEnable () {
		StartCoroutine (DespawnObject ());
	}

	public void SetSpeed (float value) {
		speed = value;
	}

	void Update () {
		var moveVelocity = speed * Time.deltaTime * transform.forward;
		transform.position += moveVelocity;
	}

	IEnumerator DespawnObject () {
		yield return new WaitForSeconds (despawnTimer);
		SimplePoolManager.instance.DisablePoolObject (transform);
		//Destroy(gameObject);
	}
}