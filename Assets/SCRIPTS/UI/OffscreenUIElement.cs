using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenUIElement : MonoBehaviour, Initializable {

	public Vector2 offScreenPos;
	public Vector2 onScreenPos;

	private RectTransform rectTransform;

	public float transitionTime = 0.25f;
	[Range (0f, 1f)]
	public float screenDarkenFactor = 0.5f;

	public InterpolationMethod interpolationMethod = InterpolationMethod.Quadratic;


	public void Initialize () {
		rectTransform = GetComponent<RectTransform> ();
	}

	void OnEnable () {
		StopAllCoroutines ();
		rectTransform.anchoredPosition = offScreenPos;
		StartCoroutine (EnterScreen ());
	}

	void OnDisable () {
		Game.staticRef.SetScreenDarkness (0f);
	}

	private IEnumerator EnterScreen () {
		float timeRemaining = transitionTime;
		while (timeRemaining >= 0f) {
			Game.staticRef.SetScreenDarkness ((1f - timeRemaining / transitionTime) * screenDarkenFactor);
			rectTransform.anchoredPosition = Interpolation.Interpolate (onScreenPos, offScreenPos, timeRemaining / transitionTime, interpolationMethod);
			timeRemaining -= Time.unscaledDeltaTime;
			yield return null;
		}
	}

	[ContextMenu ("SetOffScreenPos")]
	private void SetOffScreenPos () {
		offScreenPos = GetComponent<RectTransform> ().anchoredPosition;
	}
	[ContextMenu ("SetOnScreenPos")]
	private void SetOnScreenPos () {
		onScreenPos = GetComponent<RectTransform> ().anchoredPosition;
	}
	[ContextMenu ("SnapOffScreen")]
	private void SnapOffScreen () {
		GetComponent<RectTransform> ().anchoredPosition = offScreenPos;
	}
	[ContextMenu ("SnapOnScreen")]
	private void SnapOnScreen () {
		GetComponent<RectTransform> ().anchoredPosition = onScreenPos;
	}
}
