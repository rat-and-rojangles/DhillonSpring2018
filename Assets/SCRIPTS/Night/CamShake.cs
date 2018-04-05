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

	public void DebugModerateShake () {
		Shake (0.25f, 1f);
	}

	void Update () {
		transform.localPosition = Random.insideUnitCircle * Mathf.Lerp (strength, 0f, timeElapsed / duration);
		timeElapsed += Time.deltaTime;
	}
}
