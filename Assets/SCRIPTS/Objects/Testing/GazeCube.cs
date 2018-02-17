using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeCube : Gazeable {
	protected override void OnGazeEnter () {
		OnScreenConsole.Log (name + " gaze enter");
	}

	protected override void OnGazeExit () {
		OnScreenConsole.Log (name + " gaze exit");
	}
}
