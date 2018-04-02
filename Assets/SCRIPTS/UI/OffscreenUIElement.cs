using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenUIElement : MonoBehaviour {

	public Vector2 offScreenPos;
	public Vector2 onScreenPos;

	private RectTransform m_rectTransform;
	protected RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	public float transitionTime = 0.25f;

	public InterpolationMethod interpolationMethod = InterpolationMethod.Quadratic;

	void OnEnable () {
		StopAllCoroutines ();
		rectTransform.anchoredPosition = offScreenPos;
		StartCoroutine (EnterScreen ());
	}

	void OnDisable () {
		StopAllCoroutines ();
	}

	private IEnumerator EnterScreen () {
		float startTime = Time.realtimeSinceStartup;
		float timeRemaining = startTime + transitionTime - Time.realtimeSinceStartup;
		while (timeRemaining >= 0f) {
			timeRemaining = startTime + transitionTime - Time.realtimeSinceStartup;
			rectTransform.anchoredPosition = Interpolation.Interpolate (onScreenPos, offScreenPos, timeRemaining / transitionTime, interpolationMethod);
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
