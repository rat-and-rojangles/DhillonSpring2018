using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisualizer : MonoBehaviour {
	void OnGUI () {
		GUI.Box (new Rect (Input.mousePosition.x, -Input.mousePosition.y, Screen.width, Screen.height), "This is a box");
	}
}
