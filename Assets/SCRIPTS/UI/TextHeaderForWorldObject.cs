using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The prompt that follows the interactable item moused over. 
/// </summary>
public class TextHeaderForWorldObject : MonoBehaviour, Initializable {

	private Transform target = null;
	private RectTransform rectTransform;

	[SerializeField]
	private RectTransform canvasRect;

	private Text m_uiText;

	public void Initialize () {
		rectTransform = GetComponent<RectTransform> ();
		m_uiText = GetComponent<Text> ();
	}

	void Update () {
		if (target != null) {
			Vector2 viewportPos = Camera.main.WorldToViewportPoint (target.position);
			rectTransform.anchoredPosition = new Vector2 (((viewportPos.x * canvasRect.sizeDelta.x) - (canvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f)));
		}
		else {
			gameObject.SetActive (false);
		}
	}

	/// <summary>
	/// Set the text in the prompt.
	/// </summary>
	public void SetText (string text) {
		m_uiText.text = text;
	}

	/// <summary>
	/// Set the object this prompt is bound to. Set to null to disable this.
	/// </summary>
	public void SetTarget (Transform newTarget) {
		gameObject.SetActive (newTarget != null);
		target = newTarget;
	}
}
