using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpedometerToAnimation : MonoBehaviour {

	private Vector3? m_previousPosition = null;
	private Vector3 previousPosition {
		get {
			if (m_previousPosition == null) {
				m_previousPosition = transform.position;
			}
			return m_previousPosition.GetValueOrDefault ();
		}
		set {
			m_previousPosition = value;
		}
	}
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private float speedCutoffForMoving;

	void LateUpdate () {
		float speed = Mathf.Abs (Vector3.Distance (transform.position, previousPosition)) / Time.deltaTime;
		animator.SetBool ("Moving", speed > speedCutoffForMoving);
		previousPosition = transform.position;
	}
}
