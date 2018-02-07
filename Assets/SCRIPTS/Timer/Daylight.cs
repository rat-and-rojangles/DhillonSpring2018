using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daylight : MonoBehaviour {
	public float depletionScale = 1f;

	[SerializeField]
	[Tooltip ("Level duration in seconds. Only change in edit mode.")]
	private float initialDuration;

	/// <summary>
	/// Duration of the level in seconds.
	/// </summary>
	private float levelDuration;
	private float m_timeRemaining;
	/// <summary>
	/// Seconds remaining in the level.
	/// </summary>
	public float timeRemaining {
		get { return m_timeRemaining; }
	}

	[SerializeField]
	private DaylightUIBar daylightUIBar;

	void Awake () {
		levelDuration = initialDuration;
		m_timeRemaining = levelDuration;
	}

	void Update () {
		m_timeRemaining -= Time.deltaTime * depletionScale;
		daylightUIBar.UpdateUI (1f - (m_timeRemaining / levelDuration), m_timeRemaining);
	}
}
