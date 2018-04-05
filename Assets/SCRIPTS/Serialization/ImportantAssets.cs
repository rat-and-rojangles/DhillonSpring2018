using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImportantAssets {
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
}
