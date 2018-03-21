using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An item with no physical presence that invokes an event when you deploy it.
/// </summary>
public class CollectibleEventItem : CollectibleItem {

	[SerializeField]
	private Sprite backpackIcon;
	public override Sprite icon {
		get {
			return backpackIcon;
		}
	}

	public override string promptText {
		get { return "Not applicable, unless you reenabled the object. If so, maybe we need more abstractions?"; }
	}

	public UnityEvent onDeploy;

	public override void Deploy () {
		onDeploy.Invoke ();
	}
}
