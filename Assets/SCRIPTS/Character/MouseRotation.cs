using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour {
	[Range (0f, 90f)]
	public float maxAngleVertical = 60f;

	public float turnSpeed = 50f;

	private float currentCamXEuler = 0f;

	public Transform targetCharacter;

	void Awake () {
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {
		currentCamXEuler -= Input.GetAxis ("Mouse Y") * Time.deltaTime * turnSpeed;
		if (currentCamXEuler > maxAngleVertical) {
			currentCamXEuler = maxAngleVertical;
		}
		if (currentCamXEuler < -maxAngleVertical) {
			currentCamXEuler = -maxAngleVertical;
		}
		transform.localRotation = Quaternion.Euler (currentCamXEuler, 0f, 0f);

		targetCharacter.Rotate (0f, Input.GetAxis ("Mouse X") * Time.deltaTime * turnSpeed, 0f);
	}
}
