using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	[SerializeField]
	private Treasure [] treasures;

	public void Die (Vector2 bulletDirection) {
		foreach (Treasure t in treasures) {
			Vector2 newVel = bulletDirection.normalized;
			newVel.Rotate (Utility.randomMagnitude * 30f);
			newVel *= Random.Range (10f, 15f);
			newVel.x *= 0.5f;
			t.Release (newVel);
		}
		SoundPlayer.PlayOneShot (GameNight.staticRef.soundLibrary.oof, 2f);
		Destroy (gameObject);
	}

	[ContextMenu ("DebugDie")]
	public void DebugDie () {
		Die (transform.position - GameNight.staticRef.player.transform.position);
	}

}