using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aspects of customization for the character.
/// </summary>
public class CharacterPreferences : ScriptableObject {

	/// <summary>
	/// Name of the kid playing the game.
	/// </summary>
	public string playerName;

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

	public Texture2D shirtIcon = null;
	/// <summary>
	/// Texture2D for the shirt, based on icon and color.
	/// </summary>
	public Texture2D shirtTexture {
		get {
			Texture2D coloredShirt = TextureCompositor.BlendWithColor (ImportantAssets.baseTextureShirt, ImportantAssets.characterPreferences.favoriteColor);
			if (shirtIcon == null) {
				Debug.LogWarning ("Shirt icon is null. No icon will be shown.");
			}
			else {
				coloredShirt = TextureCompositor.CombineTextures (coloredShirt, shirtIcon);
			}
			return coloredShirt;
		}
	}

	public float favoriteColorHue;
	public Color favoriteColor {
		get { return new ColorHSV (favoriteColorHue, 1f, 1f, 1f); }
	}
}
