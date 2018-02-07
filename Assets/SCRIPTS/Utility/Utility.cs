using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utility {

	/// <summary>
	/// Returns the same color with a different transparency value. (0 to 1)
	/// </summary>
	public static Color ChangedAlpha (this Color c, float newAlphaValue) {
		return new Color (c.r, c.g, c.b, newAlphaValue);
	}

	/// <summary>
	/// Returns a random element in the collection.
	/// </summary>
	public static T RandomElement<T> (this ICollection<T> collection) {
		int current = 0;
		int magicIndex = UnityEngine.Random.Range (0, collection.Count);
		foreach (T t in collection) {
			if (current == magicIndex) {
				return t;
			}
			current++;
		}
		//this shouldn't fire, but who knows
		return default (T);
	}

	/// Use this method to get all loaded objects of some type, including inactive objects. 
	/// This is an alternative to Resources.FindObjectsOfTypeAll (returns project assets, including prefabs), and GameObject.FindObjectsOfTypeAll (deprecated).
	public static T [] FindObjectsOfTypeAll<T> () {
		List<T> results = new List<T> ();
		for (int i = 0; i < SceneManager.sceneCount; i++) {
			var s = SceneManager.GetSceneAt (i);
			if (s.isLoaded) {
				var allGameObjects = s.GetRootGameObjects ();
				for (int j = 0; j < allGameObjects.Length; j++) {
					var go = allGameObjects [j];
					results.AddRange (go.GetComponentsInChildren<T> (true));
				}
			}
		}
		return results.ToArray ();
	}
}
