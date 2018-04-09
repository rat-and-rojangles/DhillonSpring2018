using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTilt : MonoBehaviour {

	public Vector2 maxDegrees;

	void Update () {
		float mouseVerticalRatio = Mathf.InverseLerp (-Screen.height * 0.5f, Screen.height * 0.5f, Input.mousePosition.y);
		float mouseHorizontalRatio = Mathf.InverseLerp (-Screen.width * 0.5f, Screen.width * 0.5f, Input.mousePosition.x);
		transform.rotation = Quaternion.Euler (mouseVerticalRatio * maxDegrees.y, mouseHorizontalRatio * maxDegrees.x, 0f);

	}
}
