using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : OffscreenUIElement {

	private static ThoughtBubble m_current;
	/// <summary>
	/// Return the ThoughtBubble of the active scene.
	/// </summary>
	public static ThoughtBubble current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	public KeyCode closeKey;

	[SerializeField]
	private RolloutText rolloutText;

	public void SetMessage (string message) {
		if (gameObject.activeSelf) {
			gameObject.SetActive (false);
		}
		rolloutText.message = message;
		gameObject.SetActive (true);
		disappearing = false;
	}

	private bool disappearing = false;
	void Update () {
		if (Input.GetKeyDown (closeKey)) {
			CloseThought ();
		}
	}

	/// <summary>
	/// Attempts to close the thought bubble. Does nothing if the request to close is untimely.
	/// </summary>
	public void CloseThought () {
		if (rolloutText.complete && !disappearing) {
			disappearing = true;
			StartCoroutine (ExitScreen ());
		}
	}

	private IEnumerator ExitScreen () {
		Vector2 initialPosition = rectTransform.anchoredPosition;
		float timeRemaining = transitionTime;
		while (timeRemaining >= 0f) {
			rectTransform.anchoredPosition = Interpolation.Interpolate (offScreenPos, initialPosition, timeRemaining / transitionTime, interpolationMethod);
			timeRemaining -= Time.unscaledDeltaTime;
			yield return null;
		}
		gameObject.SetActive (false);
	}
}
