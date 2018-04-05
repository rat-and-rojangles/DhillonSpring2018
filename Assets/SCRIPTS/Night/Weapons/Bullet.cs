using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private const float BULLET_SPEED = 50f;

	[SerializeField]
	private new Rigidbody2D rigidbody2D;
	public void Initialize (float angleDegrees) {
		transform.position = Game.current.heroCharacter.transform.position;
		transform.rotation = Quaternion.Euler (0f, 0f, angleDegrees);
		rigidbody2D.velocity = Utility.DegreeToVector2 (angleDegrees).normalized * BULLET_SPEED;
	}

	void OnTriggerEnter2D (Collider2D other) {
		Enemy enemy = other.GetComponent<Enemy> ();
		if (enemy != null && enabled) {
			enabled = false;
			gameObject.SetActive (false);
			enemy.Die (other.transform.position - transform.position);
			CompleteCamera.current.camShake.Shake (0.1f, 0.5f);
			Destroy (gameObject);
		}
	}
}
