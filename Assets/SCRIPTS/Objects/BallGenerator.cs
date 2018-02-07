using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : Interactable {
	public override string promptText { get { return "Drop a ball"; } }

	public GameObject [] balls;

	public override void Interact () {
		GameObject ball = GameObject.Instantiate (balls.RandomElement ());
		ball.transform.position = transform.position + new Vector3 (Random.value, -1f, Random.value);
	}
}
