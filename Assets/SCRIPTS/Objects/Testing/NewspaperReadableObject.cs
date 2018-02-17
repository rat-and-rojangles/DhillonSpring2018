using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperReadableObject : Interactable {

	public GameObject newspaperUI;

	public override string promptText {
		get {
			return "Inspect Newspaper";
		}
	}

	public override void Interact () {
		newspaperUI.SetActive (true);
		Time.timeScale = 0f;
		Cursor.lockState = CursorLockMode.None;
	}
}
