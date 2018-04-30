using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCustomizations : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Slider slider;
	public Renderer demoShirt;

	public void UpdateShirt () {
		if (slider.value < 0f) {
			ImportantAssets.characterPreferences.favoriteColor = Color.black;
		}
		else if (slider.value > 1f) {
			ImportantAssets.characterPreferences.favoriteColor = Color.white;
		}
		else {
			ImportantAssets.characterPreferences.favoriteColor = new ColorHSV (slider.value, 1f, 1f, 1f);

		}
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
