using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {

	public Transform target;
	public Vector3 position;

	public void ApplyPosition () {
		target.position = position;
	}
}
