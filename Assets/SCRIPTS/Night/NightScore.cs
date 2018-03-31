using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightScore : MonoBehaviour {
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
