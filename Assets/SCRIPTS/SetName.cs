using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetName : MonoBehaviour, Initializable {

	public string prefix;
	public string suffix;

	public bool useFavoriteColor = false;

	public void Initialize () {
		Apply ();
	}

	void Start () {
		Apply ();
	}

	void OnEnable () {
		Apply ();
	}

	private void Apply () {
		UnityEngine.UI.Text myText = GetComponent<UnityEngine.UI.Text> ();
		myText.text = ImportantAssets.characterPreferences.playerName;
		myText.text = prefix + ImportantAssets.characterPreferences.playerName + suffix;
		if (useFavoriteColor) {
			myText.color = ImportantAssets.characterPreferences.favoriteColor.ChangedAlpha (1f);
		}
	}
}
