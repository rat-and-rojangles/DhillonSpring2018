using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class KeyEventListener : MonoBehaviour {

	public KeyCode key;

	public UnityEvent keyDown;

	public UnityEvent keyUp;

	void Update () {
		if (Input.GetKeyDown (key)) {
			keyDown.Invoke ();
		}
		if (Input.GetKeyUp (key)) {
			keyUp.Invoke ();
		}
	}
}
