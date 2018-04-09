using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class MoveToResources {
	[MenuItem ("Assets/Move To Resources")]
	public static void MoveSelectionToResources () {
		foreach (Object oo in Selection.objects) {
			Debug.Log (AssetDatabase.GetAssetPath (oo));
			AssetDatabase.MoveAsset (AssetDatabase.GetAssetPath (oo), "Assets/Resources");
		}
	}

	[MenuItem ("Assets/Move To Resources", true)]
	public static bool ValidateMoveSelectionToResources () {
		if (Selection.objects.Length == 0) {
			return false;
		}
		else {
			foreach (Object oo in Selection.objects) {
				if (!AssetDatabase.Contains (oo)) {
					return false;
				}
			}
			return true;
		}
	}
}
