using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenComponentTool : MonoBehaviour {
	[ContextMenu ("Ruin everything")]
	void Ruin () {
		foreach (Transform t in Utility.FindObjectsOfTypeAll<Transform> ()) {
			foreach (Component c in t.GetComponents<Component> ()) {
				if (c is MonoBehaviour || c == null) {
					DestroyImmediate (c);
				}
			}
		}
	}

	public GameObject targetObject;

	[ContextMenu ("Group Broken Objects")]
	void GroupBrokenObjects () {
		foreach (Transform t in Utility.FindObjectsOfTypeAll<Transform> ()) {
			Component [] cs = t.gameObject.GetComponents<Component> ();
			foreach (Component c in cs) {
				if (c == null) {
					t.root.SetParent (transform, true);
				}
			}
		}
	}


	[ContextMenu ("Analyze")]
	void Analyze () {
		analysisString = "";
		foreach (Component c in targetObject.GetComponents<Component> ()) {
			if (c == null) {
				analysisString += "NULL";
			}
			else {
				analysisString += c + "\n";
			}
		}
	}

	[ContextMenu ("Scrape Null")]
	void ScrapeNull () {
		foreach (Component c in targetObject.GetComponents<Component> ()) {
			if (c == null) {
				DestroyImmediate (c);
			}
		}
	}

	[TextArea (10, 50)]
	public string analysisString;
}
