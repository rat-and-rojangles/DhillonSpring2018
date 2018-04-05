using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Whenever time is stopped, an invisible screen will appear over the camera to prevent things from being clicked.
/// </summary>
public class UIClickBlocker : MonoBehaviour {

	[SerializeField]
	private Collider blocker;
	void Update () {
		blocker.enabled = Time.timeScale < 0.01f;
	}
}
