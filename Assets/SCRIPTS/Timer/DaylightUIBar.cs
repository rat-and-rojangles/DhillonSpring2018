using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaylightUIBar : MonoBehaviour {

	[SerializeField]
	private RectTransform clockRect;

	[SerializeField]
	private Image image;
	private Color initialColor;
	private Color clearBlack;

	[SerializeField]
	private Text timerText;

	private static string SecondsToTime (float seconds) {
		string minutesString = Mathf.FloorToInt (seconds / 60f).ToString ();
		string secondsString = Mathf.FloorToInt (seconds % 60f).ToString ();
		if (secondsString.Length == 1) {
			secondsString = "0" + secondsString;
		}
		return minutesString + ":" + secondsString;
	}

	[SerializeField]
	private Vector2 startPos;

	[SerializeField]
	private Vector2 endPos;

	void Awake () {
		initialColor = image.color;
		clearBlack = Color.black.ChangedAlpha (0.5f);
	}

	public void UpdateUI (float ratio, float seconds) {
		float ratioPrime = Mathf.Clamp01 (ratio);
		clockRect.anchoredPosition = Vector2.Lerp (startPos, endPos, ratioPrime);
		clockRect.rotation = Quaternion.Euler (0f, 0f, 360f * ratioPrime);
		Color uiColor = Color.Lerp (initialColor, clearBlack, ratioPrime);
		image.color = uiColor;
		timerText.color = uiColor;
		timerText.text = SecondsToTime (seconds);
	}

	[ContextMenu ("SetStartPosition")]
	private void SetStartPosition () {
		startPos = clockRect.anchoredPosition;
	}

	[ContextMenu ("SetEndPosition")]
	private void SetEndPosition () {
		endPos = clockRect.anchoredPosition;
	}

	[ContextMenu ("SnapToStartPosition")]
	private void SnapToStartPosition () {
		clockRect.anchoredPosition = startPos;
	}

	[ContextMenu ("SnapToEndPosition")]
	private void SnapToEndPosition () {
		clockRect.anchoredPosition = endPos;
	}
}
