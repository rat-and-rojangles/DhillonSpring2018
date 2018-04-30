using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyFavoriteColorToSprite : MonoBehaviour, Initializable {
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
		GetComponent<SpriteRenderer> ().color = ImportantAssets.characterPreferences.favoriteColor.ChangedAlpha (1f);

	}
}
