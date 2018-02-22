using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The prompt that follows the interactable item moused over. 
/// </summary>
public class TextHeaderForWorldObject : ObjectCenteredBillboard {

	private Text m_uiText;
	private Text uiText {
		get {
			if (m_uiText == null) {
				m_uiText = GetComponent<Text> ();
			}
			return m_uiText;
		}
	}

	/// <summary>
	/// Set the text in the prompt.
	/// </summary>
	public void SetText (string text) {
		uiText.text = text;
	}
}
