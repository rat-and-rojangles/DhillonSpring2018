using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A UI element that will follow the world position of an object.
/// </summary>
public class ObjectCenteredBillboard : MonoBehaviour {

	private Transform target = null;
	private RectTransform m_rectTransform;
	private RectTransform rectTransform {
		get {
			if (m_rectTransform == null) {
				m_rectTransform = GetComponent<RectTransform> ();
			}
			return m_rectTransform;
		}
	}

	void Update () {
		if (target != null) {
			Vector2 viewportPos = CompleteCamera.current.camera.WorldToViewportPoint (target.position);
			rectTransform.anchoredPosition = new Vector2 (((viewportPos.x * Game.current.mainCanvasRect.sizeDelta.x) - (Game.current.mainCanvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * Game.current.mainCanvasRect.sizeDelta.y) - (Game.current.mainCanvasRect.sizeDelta.y * 0.5f)));
		}
		else {
			gameObject.SetActive (false);
		}
	}

	/// <summary>
	/// Set the object this prompt is bound to. Set to null to disable this.
	/// </summary>
	public void SetTarget (Transform newTarget) {
		gameObject.SetActive (newTarget != null);
		target = newTarget;
	}
}
