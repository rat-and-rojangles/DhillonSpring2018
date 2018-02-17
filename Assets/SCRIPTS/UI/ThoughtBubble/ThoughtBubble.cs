using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : OffscreenUIElement {

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
		if (rolloutText.complete && Input.GetKeyDown (closeKey) && !disappearing) {
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

	[SerializeField]
	[TextArea (3, 10)]
	private string hackText;
	[ContextMenu ("Trigger Thought")]
	private void TriggerThought () {
		SetMessage (hackText);
	}
}
