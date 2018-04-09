using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for compositing textures with transparency at runtime.
/// </summary>
public static class TextureCompositor {

	/// <summary>
	/// Blend one texture on top of another texture, using transparency.
	/// </summary>
	public static Texture2D CombineTextures (Texture2D upper, Texture2D lower) {
		if (upper == null || lower == null) {       // null
			throw new System.Exception ("The textures should not be null.");
		}
		else if (upper.width != lower.width || upper.height != lower.height) {
			throw new System.Exception ("The textures must have the same dimensions. Consider using 512x512 as the standard.");
		}
		else {
			Color [] pixelsUpper = upper.GetPixels ();
			Color [] pixelsLower = lower.GetPixels ();
			Texture2D temp = new Texture2D (upper.width, upper.height, TextureFormat.ARGB32, false);

			for (int i = 0; i < pixelsUpper.Length; i++) {
				pixelsUpper [i] = Color.Lerp (pixelsLower [i], pixelsUpper [i], pixelsUpper [i].a);
			}

			temp.SetPixels (pixelsUpper);
			temp.Apply ();
			return temp;
		}
	}

	/// <summary>
	/// Blend one texture with a color. Transparency is supported.
	/// </summary>
	public static Texture2D BlendWithColor (Texture2D texture, Color blendColor) {
		if (texture == null) {       // null
			throw new System.Exception ("The texture should not be null.");
		}
		else {
			Color [] pixels = texture.GetPixels ();
			Texture2D temp = new Texture2D (texture.width, texture.height, TextureFormat.ARGB32, false);

			for (int i = 0; i < pixels.Length; i++) {
				pixels [i] = pixels [i] * blendColor;
			}

			temp.SetPixels (pixels);
			temp.Apply ();
			return temp;
		}
	}

	public static Sprite Texture2DToSprite (Texture2D texture2D) {
		return Sprite.Create (texture2D, new Rect (0f, 0f, texture2D.width, texture2D.height), new Vector2 (texture2D.width * 0.5f, texture2D.height * 0.5f));
	}
}