using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rather than being in real time, each interaction can reduce time.
/// </summary>
public class LevelTimer : MonoBehaviour {

	private static LevelTimer m_current;
	public static LevelTimer current {
		get {
			return m_current;
		}
	}

	private float m_time;
	public float time {
		get { return m_time; }
	}
	private void SetTime (float value) {
		m_time = value;
		uiBar.ratio = m_time;
	}


	[SerializeField]
	private UIBar uiBar;

	void Awake () {
		m_time = 1f;
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	public void ReduceTime (float amount) {
		ShortMessageGenerator.current.GenerateShortMessage ("Lost Time!");
		float newTime = m_time - amount;
		SetTime (Mathf.Clamp01 (newTime));
		if (newTime <= 0f) {
			SwitchToNight.current.MissBus ();
		}
	}
	public void Reset () {
		SetTime (1f);
	}
}
