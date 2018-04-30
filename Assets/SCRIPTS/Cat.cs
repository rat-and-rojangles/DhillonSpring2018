using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Interactable {

	[SerializeField]
	private BoxCollider areaTrigger;

	public float walkSpeed;
	public InterpolationMethod interpolationMethod;

	public AudioClip meow;

	public override string promptText {
		get {
			return "Play with cat";
		}
	}

	private Vector3 GetPointInArea () {
		Vector3 tempPoint = areaTrigger.RandomPointWithin ();
		tempPoint.y = transform.position.y;
		return tempPoint;
	}

	public override void Interact () {
		SoundPlayer.PlayOneShot (meow);
		LevelTimer.current.ReduceTime (0.05f);
		StartCoroutine (Walk ());
	}

	private IEnumerator Walk () {
		Vector3 initialPoint = transform.position;
		Vector3 destination = GetPointInArea ();
		transform.LookAt (destination);
		gazeable = false;
		Timer timer = new Timer (Vector3.Distance (initialPoint, destination) / walkSpeed);
		StartCoroutine (timer.StartTicking ());
		while (!timer.complete) {
			transform.position = Interpolation.Interpolate (initialPoint, destination, timer.ratio, interpolationMethod);
			yield return null;
		}
		gazeable = true;
	}
}
