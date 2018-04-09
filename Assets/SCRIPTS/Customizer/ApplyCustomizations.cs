using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCustomizations : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Slider slider;
	public Renderer demoShirt;

	public void UpdateShirt () {
		ImportantAssets.characterPreferences.favoriteColorHue = slider.value;
		demoShirt.materials [0].mainTexture = ImportantAssets.characterPreferences.shirtTexture;
	}

	public void SetPreferredShirtIcon (Texture2D newShirtIcon) {
		ImportantAssets.characterPreferences.shirtIcon = newShirtIcon;
	}

	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			StopAllCoroutines ();
			StartCoroutine (DelayThenUpdateShirt ());
		}
	}

	private IEnumerator DelayThenUpdateShirt () {
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		UpdateShirt ();
	}
}
