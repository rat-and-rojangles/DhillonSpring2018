using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableEventObject : Interactable {

	public string text;
	public UnityEvent onInteract;

	public override string promptText {
		get {
			return text;
		}
	}

	public override void Interact () {
		onInteract.Invoke ();
	}
}
