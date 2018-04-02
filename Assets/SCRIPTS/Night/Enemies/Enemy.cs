using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

	public int treasureCount;
	[SerializeField]
	private GameObject treasurePrefab;

	public void Die (Vector2 bulletDirection) {
		for (int x = 0; x < treasureCount; x++) {
			Treasure t = Instantiate (treasurePrefab, transform.position, Quaternion.identity).GetComponent<Treasure> ();
			Vector2 newVel = bulletDirection.normalized;
			newVel.Rotate (Utility.randomMagnitude * 20f);
			newVel *= Random.Range (7f, 12f);
			newVel.x *= 0.75f;
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