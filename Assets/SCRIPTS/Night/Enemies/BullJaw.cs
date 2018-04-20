using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullJaw : MonoBehaviour {

	public float cackleSpeed;
	public float maxUnhingeDegrees;
	[SerializeField]
	private Transform wholeHead;

	public float rotationSpeed;

	void Update () {
		transform.localRotation = Quaternion.Euler (Mathf.Abs (1f - Mathf.Sin (Time.time * cackleSpeed)) * maxUnhingeDegrees, 0f, 0f);
		// wholeHead.LookAt (Game.current.heroCharacter.transform);

		Vector3 direction = Game.current.heroCharacter.transform.position - transform.position;
		Quaternion toRotation = Quaternion.FromToRotation (wholeHead.forward, direction);
		wholeHead.rotation = Quaternion.Slerp (transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
	}
}
