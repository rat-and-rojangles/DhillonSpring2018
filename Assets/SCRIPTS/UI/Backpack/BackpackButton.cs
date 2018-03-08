using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour {

	[SerializeField]
	private Button button;
	[SerializeField]
	private Image icon;

	/// <summary>
	/// Fill this icon with the data from the item. Button is disabled if null.
	/// </summary>
	public void UpdateWithData (CollectibleItem item) {
		if (item == null) {
			button.interactable = false;
			icon.enabled = false;
		}
		else {
			button.interactable = true;
			icon.enabled = true;
			icon.sprite = item.icon;
		}
	}
}
