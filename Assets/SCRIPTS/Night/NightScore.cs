using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightScore : MonoBehaviour {
	private static NightScore m_current;
	/// <summary>
	/// Return the NightScore of the active scene.
	/// </summary>
	public static NightScore current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}
	private int m_score = 0;
	public int score {
		get {
			return m_score;
		}
		set {
			m_score = value;
			scoreDisplay.text = m_score.ToString ();
		}
	}

	[SerializeField]
	private Text scoreDisplay;

}
