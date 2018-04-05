using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortMessageGenerator : MonoBehaviour {

	private static ShortMessageGenerator m_current;
	/// <summary>
	/// Return the ShortMessageGenerator of the active scene.
	/// </summary>
	public static ShortMessageGenerator current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}
	public void GenerateShortMessage (string message, HealthCategory healthCategory) {
		GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		shortMessage.GetComponent<ShortMessage> ().Setup (message, healthCategory);
	}

	public void GenerateShortMessage (string message) {
		GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		if (Game.current.heroCharacter != null) {
			Vector2 viewportPos = CompleteCamera.current.camera.WorldToViewportPoint (Game.current.heroCharacter.transform.position);
			(shortMessage.transform as RectTransform).anchoredPosition = new Vector2 (((viewportPos.x * Game.current.mainCanvasRect.sizeDelta.x) - (Game.current.mainCanvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * Game.current.mainCanvasRect.sizeDelta.y) - (Game.current.mainCanvasRect.sizeDelta.y * 0.5f)));
		}
		shortMessage.GetComponent<ShortMessage> ().Setup (message, HealthCategory.Uncategorized);
	}

}
