using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkAboutSomething : Interactable {

	public string subject;
	[TextArea (3, 10)]
	public string message;

	public override string promptText {
		get {
			return "Think about " + subject;
		}
	}

	public override void Interact () {
		Game.staticRef.thoughtBubble.SetMessage (message);
	}
}
