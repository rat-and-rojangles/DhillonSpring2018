using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float runSpeed = 1f;
	public float gravityScale = 1f;
	public float jumpStrength = 100f;
	public float timeToMaxSpeed = 0.5f;
	private float timeRunning = 0f;
	private Vector2 previousInputVector = Vector2.down;

	private Vector3 gravity = Vector3.zero;

	private CharacterController characterController;

	void Awake () {
		characterController = GetComponent<CharacterController> ();
	}

	private float GetRunSpeedMultiplier () {
		return Mathf.Lerp (runSpeed * 0.5f, runSpeed, timeRunning / timeToMaxSpeed);
	}

	void Update () {
		Vector2 inputVector = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (previousInputVector.magnitude > 0.1f && Vector2.Angle (previousInputVector, inputVector) < 90f) {
			timeRunning += Time.deltaTime;
		}
		else {
			timeRunning = 0f;
		}
		gravity += Physics.gravity * gravityScale * Time.deltaTime;
		characterController.Move (((transform.forward * inputVector.y + transform.right * inputVector.x).normalized * GetRunSpeedMultiplier () + gravity) * Time.deltaTime);
		if (characterController.isGrounded) {
			gravity = Vector3.zero;
			if (Input.GetButtonDown ("Jump")) {
				gravity = Vector3.up * jumpStrength;
			}
		}
		previousInputVector = inputVector;
	}
}
