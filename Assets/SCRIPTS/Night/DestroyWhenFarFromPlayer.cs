using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenFarFromPlayer : MonoBehaviour {

	public float maxDistance;

	void Update () {
		if (Vector2.Distance (transform.position, GameNight.staticRef.player.transform.position) > maxDistance) {
			Destroy (gameObject);
		}
	}
}
