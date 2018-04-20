using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// LIST OF ALL REQUIRED RESOURCE NAMES - AND TYPES
/// 
/// BaseTextureShirt - Texture2D
/// HighlightMaterial - Material
/// ShortMessage - prefab
/// SoundLibrary - SoundLibrary
/// HealthCategoryResources - HealthCategoryResources
/// CharacterPreferences - CharacterPreferences
/// HeroPrefabs - PrefabArray
/// 

/// <summary>
/// Bridge to various assets in Resources to cut down on cluttered references in the editor.
/// </summary>
public static class ImportantAssets {
	private static Texture2D m_baseTextureShirt = null;
	public static Texture2D baseTextureShirt {
		get {
			if (m_baseTextureShirt == null) {
				m_baseTextureShirt = Resources.Load<Texture2D> ("BaseTextureShirt");
			}
			return m_baseTextureShirt;
		}
	}
	private static Material m_highlightMaterial = null;
	public static Material highlightMaterial {
		get {
			if (m_highlightMaterial == null) {
				m_highlightMaterial = Resources.Load<Material> ("HighlightMaterial");
			}
			return m_highlightMaterial;
		}
	}

	private static GameObject m_shortMessagePrefab = null;
	public static GameObject shortMessagePrefab {
		get {
			if (m_shortMessagePrefab == null) {
				m_shortMessagePrefab = Resources.Load<GameObject> ("ShortMessage");
			}
			return m_shortMessagePrefab;
		}
	}

	private static SoundLibrary m_soundLibrary = null;
	public static SoundLibrary soundLibrary {
		get {
			if (m_soundLibrary == null) {
				m_soundLibrary = Resources.Load<SoundLibrary> ("SoundLibrary");
			}
			return m_soundLibrary;
		}
	}

	private static HealthCategoryResources m_healthCategoryResources = null;
	public static HealthCategoryResources healthCategoryResources {
		get {
			if (m_healthCategoryResources == null) {
				m_healthCategoryResources = Resources.Load<HealthCategoryResources> ("HealthCategoryResources");
			}
			return m_healthCategoryResources;
		}
	}

	private static CharacterPreferences m_characterPreferences = null;
	public static CharacterPreferences characterPreferences {
		get {
			if (m_characterPreferences == null) {
				m_characterPreferences = Resources.Load<CharacterPreferences> ("CharacterPreferences");
			}
			return m_characterPreferences;
		}
	}

	private static MiscData m_miscData = null;
	public static MiscData miscData {
		get {
			if (m_miscData == null) {
				m_miscData = Resources.Load<MiscData> ("MiscData");
			}
			return m_miscData;
		}
	}

	private static GameObject [] m_heroPrefabs = null;
	/// <summary>
	/// All prefabs for the night character. Must be complete and functional.
	/// </summary>
	public static GameObject [] heroPrefabs {
		get {
			if (m_heroPrefabs == null) {
				m_heroPrefabs = Resources.Load<PrefabArray> ("HeroPrefabs").prefabs;
			}
			return m_heroPrefabs;
		}
	}
}
