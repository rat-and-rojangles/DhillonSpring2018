using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToNight : MonoBehaviour, Initializable {
	private static SwitchToNight m_current = null;
	public static SwitchToNight current {
		get {
			return m_current;
		}
	}
	public void Initialize () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	private bool missedBus = false;

	public void MissBus () {
		missedBus = true;
		gameObject.SetActive (true);
		ThoughtBubble.current.SetMessage ("Oh no, I'm going to have to sprint for the bus!");
		Game.current.dayCharacter.controllable = false;
	}
	public void ExitHouse () {
		missedBus = false;
		gameObject.SetActive (true);
		ThoughtBubble.current.SetMessage ("I made it to bus with plenty of time to spare.");
		Game.current.dayCharacter.controllable = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (missedBus) {
				Energy.current.energyRatio *= 0.5f;
			}
			PlayerPrefs.SetFloat ("StartingEnergy", Energy.current.energyRatio);
			Game.current.UnlockCursor ();
			SceneManager.LoadScene ("HeroNight");
		}
	}
}
