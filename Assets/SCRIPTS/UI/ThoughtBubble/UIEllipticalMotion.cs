using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will rotate in a circle, maintaining its orientations. This object is expected NOT to have its local position change except with this script.
/// </summary>
public class UIEllipticalMotion : MonoBehaviour, Initializable {

	public float radius;
	public float cycleDuration;
	private Vector2 initialPosition;
	private RectTransform rectTransform;

	[Range(0f,1f)]
	public float xRatio = 1f;
	[Range(0f,1f)]
	public float yRatio = 1f;

	public void Initialize () {
		rectTransform = GetComponent<RectTransform> ();
		initialPosition = rectTransform.anchoredPosition;
	}

	private float GetParameterizedT () {
		return 2f * Mathf.PI * (Time.time % cycleDuration) / cycleDuration;
	}

	void Update () {
		float parameterizedT = GetParameterizedT ();
		rectTransform.anchoredPosition = initialPosition + radius * new Vector2 (Mathf.Cos (parameterizedT) * xRatio, Mathf.Sin (parameterizedT) * yRatio);
	}
}
