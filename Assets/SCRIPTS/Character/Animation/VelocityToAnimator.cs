using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityToAnimator : MonoBehaviour {

	public Animator animator;
	public CharacterController characterController;
	public PlayerCharacter playerCharacter;

	private bool wasGroundedLastFrame;

	void Start () {
		wasGroundedLastFrame = characterController.isGrounded;
	}

	void Update () {
		// animator.SetFloat ("LateralSpeed", characterController.velocity.x / playerCharacter.runSpeed);
		// animator.SetFloat ("ForwardSpeed", characterController.velocity.z / playerCharacter.runSpeed);
		// animator.SetBool ("Grounded", characterController.isGrounded);
		// if (wasGroundedLastFrame != characterController.isGrounded) {
		// 	if (characterController.isGrounded) {
		// 		animator.SetTrigger ("Land");
		// 	}
		// 	else if (characterController.velocity.y > 0.01f) {
		// 		animator.SetTrigger ("Jump");
		// 	}
		// }
		// wasGroundedLastFrame = characterController.isGrounded;

		animator.SetFloat ("LateralSpeed", characterController.velocity.x / playerCharacter.runSpeed);
		animator.SetFloat ("ForwardSpeed", characterController.velocity.z / playerCharacter.runSpeed);
		animator.SetBool ("Grounded", characterController.isGrounded);
		wasGroundedLastFrame = characterController.isGrounded;
	}
}
