using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aspects of customization for the character.
/// </summary>
public class CharacterPreferences : ScriptableObject {

	public int heroModelIndex = 0;
	/// <summary>
	/// Prefab for night hero, based on customization.
	/// </summary>
	public GameObject heroPrefab {
		get {
			if (!ImportantAssets.heroPrefabs.ValidIndex (heroModelIndex)) {
				Debug.LogWarning ("Invalid hero prefab index. Loading default hero.");
				return ImportantAssets.heroPrefabs [0];
			}
			else {
				return ImportantAssets.heroPrefabs [heroModelIndex];
			}
		}
	}

	public int shirtLogoIndex = 0;
	/// <summary>
	/// Texture2D for the shirt, based on icon and color.
	/// </summary>
	public Texture2D shirtTexture {
		get {
			return null;
			if (!ImportantAssets.heroPrefabs.ValidIndex (heroModelIndex)) {
				Debug.LogWarning ("Invalid hero prefab index. Loading default hero.");
				// return ImportantAssets.heroPrefabs [0];
			}
			else {
				// return ImportantAssets.heroPrefabs [heroModelIndex];
			}
		}
	}

	public float favoriteColorHue;
	public Color favoriteColor {
		get { return new ColorHSV (favoriteColorHue, 1f, 1f, 1f); }
	}
}
