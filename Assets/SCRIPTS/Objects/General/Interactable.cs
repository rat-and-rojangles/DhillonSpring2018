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
		TextHeaderForWorldObject.current.SetText (promptText);
		TextHeaderForWorldObject.current.SetTarget (transform);
	}
	protected override void OnGazeExit () {
		if (TextHeaderForWorldObject.current != null) {		// suppresses the irrelevant OnDestroy errors
			TextHeaderForWorldObject.current.SetTarget (null);
		}
	}

	private void OnDisable () {
		OnMouseExit ();
		OnGazeExit ();
	}
}
