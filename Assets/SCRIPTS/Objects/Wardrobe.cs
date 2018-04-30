using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : Interactable {

	[SerializeField]
	private GameObject customizationUI;

	public override string promptText {
		get {
			return "Change clothes";
		}
	}

	public override void Interact () {
		Game.current.UnlockCursor ();
		Game.current.dayCharacter.SetFrontView (true);
		customizationUI.SetActive (true);
		// open up some clothes changing UI prompt
	}
}
