using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aspects of customization for the character.
/// </summary>
public class CharacterPreferences : ScriptableObject {

	public int heroModelIndex = 0;

	public float favoriteColorHue;
	public Color favoriteColor {
		get { return new ColorHSV (favoriteColorHue, 1f, 1f, 1f); }
	}
}
