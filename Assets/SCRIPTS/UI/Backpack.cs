using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : OffscreenUIElement {


	private bool disappearing = false;

	public void Close () {
		if (!disappearing) {
			Cursor.lockState = CursorLockMode.Locked;
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
		Time.timeScale = 1f;
		disappearing = false;
	}
}
