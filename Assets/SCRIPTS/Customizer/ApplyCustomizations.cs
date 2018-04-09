using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyCustomizations : MonoBehaviour {

	public float hue;
	public Renderer demoShirt;

	[SerializeField]
	private Texture2D baseTexture;

	public void ApplyShirt (Texture2D shirtIcon) {
		ImportantAssets.characterPreferences.favoriteColorHue = hue;
		Texture2D coloredShirt = TextureCompositor.BlendWithColor (baseTexture, ImportantAssets.characterPreferences.favoriteColor);
		demoShirt.materials [0].mainTexture = TextureCompositor.CombineTextures (coloredShirt, shirtIcon);
	}
}
