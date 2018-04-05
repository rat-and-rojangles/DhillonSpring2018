using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenFarFromPlayer : MonoBehaviour {

	public float maxDistance;

	void Update () {
		if (Vector2.Distance (transform.position, Game.current.heroCharacter.transform.position) > maxDistance) {
			Destroy (gameObject);
		}
	}
}
