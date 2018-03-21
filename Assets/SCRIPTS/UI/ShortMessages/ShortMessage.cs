using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortMessage : MonoBehaviour {
	private RectTransform m_rectTransform;
	private RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	private Text m_text;
	public Text text {
		get {
			if (m_text == null) {
				m_text = GetComponent<Text> ();
			}
			return m_text;
		}
	}

	void Start () {
		StartCoroutine (Ascend ());
	}

	public float ascensionDuration = 1.5f;
	public float ascensionHeight = 222f;

	private IEnumerator Ascend () {
		float startTime = Time.realtimeSinceStartup;
		Color oldColor = text.color;
		Color newColor = oldColor.ChangedAlpha (0f);
		while (Time.realtimeSinceStartup < startTime + ascensionDuration) {
			float ratio = (Time.realtimeSinceStartup - startTime) / ascensionDuration;
			rectTransform.anchoredPosition = Interpolation.Interpolate (Vector2.zero, Vector2.up * ascensionHeight, ratio, InterpolationMethod.Quadratic);
			text.color = Interpolation.Interpolate (oldColor, newColor, ratio, InterpolationMethod.Quadratic);
			yield return null;
		}
		Destroy (gameObject);
	}
}
