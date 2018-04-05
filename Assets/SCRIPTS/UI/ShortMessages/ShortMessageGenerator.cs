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


	public void GenerateShortMessage (string message) {
		GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		shortMessage.GetComponent<ShortMessage> ().text.text = message;
	}
}
