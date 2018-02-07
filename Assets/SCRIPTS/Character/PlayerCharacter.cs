using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float runSpeed = 1f;
	public float gravityScale = 1f;
	public float jumpStrength = 100f;

	private Vector3 gravity = Vector3.zero;

	private CharacterController characterController;

	void Awake () {
		characterController = GetComponent<CharacterController> ();
	}

	void Update () {
		gravity += Physics.gravity * gravityScale * Time.deltaTime;
		characterController.Move (((transform.forward * Input.GetAxis ("Vertical") + transform.right * Input.GetAxis ("Horizontal")).normalized * runSpeed + gravity) * Time.deltaTime);
		if (characterController.isGrounded) {
			gravity = Vector3.zero;
			if (Input.GetButtonDown ("Jump")) {
				gravity = Vector3.up * jumpStrength;
			}
		}
	}
}
