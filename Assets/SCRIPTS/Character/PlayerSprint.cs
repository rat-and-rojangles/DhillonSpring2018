using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour {
	public KeyCode sprintKey = KeyCode.LeftShift;

	public bool isSprinting {
		get {
			return Input.GetKey (sprintKey);
		}
	}

	public float timeSprinting {
		get { throw new System.NotImplementedException (); }
	}

	void Update () {
		//
	}
}
