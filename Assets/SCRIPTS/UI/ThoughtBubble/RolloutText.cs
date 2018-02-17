using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Text that fills out character by character after being enabled.
/// </summary>
[RequireComponent (typeof (Text))]
public class RolloutText : MonoBehaviour {

	/// <summary>
	/// Rate at which the characters roll out, in characters per second. If this value is less than zero, text will appear immediately.
	/// </summary>
	public float speed = 10f;

	private Text m_text = null;
	private Text text {
		get {
			if (m_text == null) {
				m_text = GetComponent<Text> ();
			}
			return m_text;
		}
	}

	/// <summary>
	/// The final message that will be displayed.
	/// </summary>
	[TextArea (3, 10)]
	public string message;
	private float timeElapsed;

	[SerializeField]
	private GameObject nextButton;
	/// <summary>
	/// Is the rollout finished and the next button is showing?
	/// </summary>
	public bool complete {
		get {
			return nextButton.activeSelf;
		}
	}

	void OnEnable () {
		timeElapsed = 0f;
		nextButton.SetActive (false);
		text.text = "";
	}

	void Update () {
		if (!complete) {
			text.text = message.Substring (0, Mathf.FloorToInt (Mathf.Clamp (timeElapsed * speed, 0f, message.Length)));
			if (text.text.Length == message.Length) {
				nextButton.SetActive (true);
			}
			timeElapsed += Time.unscaledDeltaTime;
		}
	}
}
