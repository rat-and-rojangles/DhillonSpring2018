using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlMouse : MonoBehaviour {
	[Range (0f, 90f)]
	public float maxAngleVertical = 60f;

	public float turnSpeed = 50f;

	private float currentCamXEuler = 0f;

	public Transform targetCharacter;

	private Vector3 camInitialLocalPos;
	private Quaternion camInitialLocalRot;

	private bool frontPerspective = false;
	/// <summary>
	/// False is normal cam, true is looking at character
	/// </summary>
	public void SetFrontPerspective (bool value) {
		if (value) {
			transform.localPosition = camInitialLocalPos + new Vector3 (0.5f, -1f, 1f);
			transform.localRotation = Quaternion.Euler (camInitialLocalRot.eulerAngles + Vector3.up * 222f);
		}
		else {
			transform.localPosition = camInitialLocalPos;
			transform.localRotation = camInitialLocalRot;
		}
		frontPerspective = value;
	}

	void Awake () {
		Cursor.lockState = CursorLockMode.Locked;
		camInitialLocalPos = transform.localPosition;
		camInitialLocalRot = transform.localRotation;
	}

	void Update () {
		if (!frontPerspective && Game.current.dayCharacter.controllable) {
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
}
