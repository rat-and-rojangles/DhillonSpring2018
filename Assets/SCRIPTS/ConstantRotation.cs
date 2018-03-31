using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour {

	public Vector3 eulersPerSecond;

	void Update () {
		transform.localRotation = Quaternion.Euler (transform.localRotation.eulerAngles + eulersPerSecond * Time.deltaTime);
	}
}
