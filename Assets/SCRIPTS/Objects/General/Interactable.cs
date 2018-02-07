using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objects that the player can interact with.
/// </summary>
public abstract class Interactable : Gazeable {
	public abstract void Interact ();

	public abstract string promptText { get; }

	public virtual void Update () {
		if (currentlyInGaze && Input.GetMouseButtonDown (0)) {
			Interact ();
		}
	}

	protected override void OnGazeEnter () {
		Game.staticRef.screenInteractPromptText.SetText (promptText);
		Game.staticRef.screenInteractPromptText.SetTarget (transform);
	}
	protected override void OnGazeExit () {
		Game.staticRef.screenInteractPromptText.SetTarget (null);
	}
}
