using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleChanger : MonoBehaviour {
	public void SetTimeScale (float timeScale) {
		Time.timeScale = timeScale;
	}
}
