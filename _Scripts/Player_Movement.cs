using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    [SerializeField] private float speed, dashSpeed;

    [SerializeField] private Transform leftPosition, rightPosition;
    [SerializeField, ReadOnly] private float zMax, zMin;

    private bool isLeft = true;
    float newZPos = 0;
    private Animator animtr;

    // Use this for initialization
    void Start () {
        animtr = GetComponentInChildren<Animator> ();

        zMin = leftPosition.position.z;
        zMax = rightPosition.position.z;
    }

    // Update is called once per frame
    void Update () {
        MoveLeftOrRight ();

        MoveForward ();
        if (Mathf.Abs (transform.position.x) <= 0) {
            Idle ();
        }
    }

    void MoveLeftOrRight () {
        if (Input.GetButtonDown ("Left") && !isLeft) {
            isLeft = true;

        } else if (Input.GetButtonDown ("Right") && isLeft) {
            isLeft = false;
        }

        if (isLeft) {
            newZPos = Mathf.Lerp (transform.position.z, zMin, dashSpeed * Time.deltaTime);
        } else if (!isLeft) {
            newZPos = Mathf.Lerp (transform.position.z, zMax, dashSpeed * Time.deltaTime);
        }

        transform.position = new Vector3 (transform.position.x, transform.position.y, newZPos);
        ClampPosition ();
    }

    void ClampPosition () {
        var clampPos = Mathf.Clamp (transform.position.z, zMin, zMax);
        transform.position = new Vector3 (transform.position.x, transform.position.y, clampPos);
    }

    void MoveForward () {
        transform.position += speed * Time.deltaTime * transform.forward;
        animtr.SetFloat ("Speed", 1);
    }

    void Idle () {
        animtr.SetFloat ("Speed", 0);
    }
}