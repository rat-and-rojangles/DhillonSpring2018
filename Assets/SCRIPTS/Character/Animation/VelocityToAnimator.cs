using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityToAnimator : MonoBehaviour {

	public Animator animator;
	public CharacterController characterController;
	public DayCharacter playerCharacter;

	void Update () {
		animator.SetFloat ("LateralSpeed", characterController.transform.InverseTransformDirection(characterController.velocity).x / playerCharacter.runSpeed);
		animator.SetFloat ("ForwardSpeed", characterController.transform.InverseTransformDirection(characterController.velocity).z / playerCharacter.runSpeed);
		animator.SetBool ("Grounded", characterController.isGrounded);
	}
}
