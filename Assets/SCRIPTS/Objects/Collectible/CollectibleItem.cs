using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactable object that can be added to backpack.
/// </summary>
public abstract class CollectibleItem : Interactable {

	public abstract Sprite icon { get; }

	public override void Interact () {
		Game.staticRef.backpack.CollectItem (this);
	}

	/// <summary>
	/// Called from the backpack. This item's effect when selected in the backpack.
	/// </summary>
	public abstract void Deploy ();
}
