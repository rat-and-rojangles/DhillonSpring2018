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

	void Start () {
		StartCoroutine (Ascend ());
	}

	public float ascensionDuration = 1.5f;
	public float ascensionHeight = 222f;

	[SerializeField]
	private Text text;
	[SerializeField]
	private Image icon1;
	[SerializeField]
	private Image icon2;

	public void Setup (string message, HealthCategory healthCategory = HealthCategory.Uncategorized) {
		text.text = message;
		if (healthCategory != HealthCategory.Uncategorized) {
			var data = healthCategory.GetData ();
			text.color = data.color;
			icon1.sprite = data.icon;
			icon2.sprite = data.icon;

			icon1.color = data.color.ChangedAlpha (0.5f);
			icon2.color = icon1.color;
		}
	}

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
