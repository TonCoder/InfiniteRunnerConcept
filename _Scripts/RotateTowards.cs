using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RotateTowards : MonoBehaviour {

	[SerializeField] private LayerMask LayertoInteractWith;
	[SerializeField] private Transform ObjectToRotate;
	[SerializeField] private Vector3 vectorUp;
	[SerializeField, ReadOnly] private bool isTargetMouse = true;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isTargetMouse) {
			// var screenPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// Debug.Log (screenPoint);
			// float rotatePos = Mathf.Lerp (ObjectToRotate.rotation.x, screenPoint.y, rotateSpeed);

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 500, LayertoInteractWith)) {
				ObjectToRotate.LookAt (hit.point, vectorUp);
			}
		}
	}
}