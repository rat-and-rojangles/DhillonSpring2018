using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

	private float duration;
	private float timeElapsed = 1f;
	private float strength = 1f;

	/// <summary>
	/// Shake the camera.
	/// </summary>
	public void Shake (float duration, float strength) {
		timeElapsed = 0f;
		this.duration = duration;
		this.strength = strength;
	}

	void Update () {
		transform.localPosition = Random.insideUnitCircle * Mathf.Lerp (strength, 0f, timeElapsed / duration);
		timeElapsed += Time.deltaTime;
	}
}
