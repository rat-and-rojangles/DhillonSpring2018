using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : Interactable {
	public override string promptText { get { return "Kick ball"; } }

	public override void Interact () {
		GetComponent<Rigidbody> ().AddForce (transform.position - Game.current.dayCharacter.transform.position, ForceMode.Impulse);
	}
}
