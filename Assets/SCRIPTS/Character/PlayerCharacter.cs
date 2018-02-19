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

	private PlayerSprint playerSprint;

	private Energy m_energy;
	/// <summary>
	/// Dhillon's energy control
	/// </summary>
	public Energy energy {
		get { return m_energy; }
	}

	void Awake () {
		characterController = GetComponent<CharacterController> ();
		playerSprint = GetComponent<PlayerSprint> ();
		m_energy = GetComponent<Energy> ();
	}

	private float GetRunSpeedMultiplier () {
		return Mathf.Lerp (runSpeed * 0.5f, runSpeed, timeRunning / timeToMaxSpeed);
	}

	private Vector2 ModifyInputVectorForSprint (Vector2 inputVector) {
		Vector2 normalized = inputVector.normalized;
		if (playerSprint.isSprinting && normalized.y > 0f) {
			return new Vector2 (normalized.x, normalized.y * 2f);
		}
		else {
			return normalized;
		}
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
		inputVector = ModifyInputVectorForSprint (inputVector);
		characterController.Move (((transform.forward * inputVector.y + transform.right * inputVector.x) * GetRunSpeedMultiplier () + gravity) * Time.deltaTime);
		if (characterController.isGrounded) {
			gravity = Vector3.zero;
			if (Input.GetButtonDown ("Jump")) {
				gravity = Vector3.up * jumpStrength;
			}
		}
		previousInputVector = inputVector;
	}
}
