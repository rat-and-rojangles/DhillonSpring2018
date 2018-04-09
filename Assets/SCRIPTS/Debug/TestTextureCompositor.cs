using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTextureCompositor : MonoBehaviour {
	public Image output;
	public Image inputUpper;
	public Image inputLower;

	public Texture2D textureUpper;
	public Texture2D textureLower;

	public void Combine () {
		output.sprite = TextureCompositor.Texture2DToSprite (TextureCompositor.CombineTextures (inputUpper.sprite.texture, inputLower.sprite.texture));
	}

	public void UpdateImages () {
		inputUpper.sprite = TextureCompositor.Texture2DToSprite (textureUpper);
		inputLower.sprite = TextureCompositor.Texture2DToSprite (textureLower);
	}


}
