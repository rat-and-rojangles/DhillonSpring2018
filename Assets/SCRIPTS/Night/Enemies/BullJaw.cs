using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullJaw : MonoBehaviour {

	public float cackleSpeed;
	public float maxUnhingeDegrees;
	[SerializeField]
	private Transform wholeHead;

	public float rotationSpeed;

	private float? m_timeOffset = null;
	private float timeOffset {
		get {
			if (m_timeOffset == null) {
				m_timeOffset = Random.Range (0f, cackleSpeed);
			}
			return m_timeOffset.GetValueOrDefault ();
		}
	}

	void Update () {
		transform.localRotation = Quaternion.Euler (Mathf.Abs (1f - Mathf.Sin (Time.time * cackleSpeed + timeOffset)) * maxUnhingeDegrees, 0f, 0f);
		Quaternion initial = wholeHead.transform.rotation;
		wholeHead.LookAt (Game.current.heroCharacter.transform);
		Quaternion final = wholeHead.transform.rotation;
		wholeHead.transform.rotation = Quaternion.Lerp (initial, final, Time.deltaTime * 1f);


		// Vector3 direction = Game.current.heroCharacter.transform.position - transform.position;
		// Quaternion toRotation = Quaternion.FromToRotation (wholeHead.forward, direction);
		// wholeHead.rotation = Quaternion.Slerp (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
	}
}
