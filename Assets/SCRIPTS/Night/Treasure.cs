using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

	[SerializeField]
	private new Rigidbody2D rigidbody2D;

	[SerializeField]
	private new Collider2D collider2D;

	[SerializeField]
	private new MeshRenderer renderer;

	public void Release (Vector2 velocity) {
		transform.SetParent (null, true);
		gameObject.SetActive (true);
		rigidbody2D.velocity = velocity;
	}

	public void Disappear () {
		GameNight.staticRef.score.score++;
		SoundPlayer.PlayOneShot (GameNight.staticRef.soundLibrary.powerup);
		rigidbody2D.isKinematic = true;
		StartCoroutine (DisappearHelper ());
	}

	private IEnumerator DisappearHelper () {
		Vector3 initialPosition = transform.position;
		Vector3 finalPosition = transform.position + Vector3.up * 4f;
		Timer timer = new Timer (0.65f);
		StartCoroutine (timer.StartTicking ());

		while (!timer.complete) {
			transform.position = Interpolation.Interpolate (initialPosition, finalPosition, timer.ratio, InterpolationMethod.Quadratic);
			renderer.material.color = renderer.material.color.ChangedAlpha (1f - timer.ratio);
			yield return null;
		}
		Destroy (gameObject);
	}

}
