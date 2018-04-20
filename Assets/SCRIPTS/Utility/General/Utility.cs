using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utility {

	/// <summary>
	/// Random number from -1 to 1, inclusive.
	/// </summary>
	/// <returns></returns>
	public static float randomMagnitude {
		get {
			return Random.Range (-1f, 1f);
		}
	}

	public static Vector2 RadianToVector2 (float radian) {
		return new Vector2 (Mathf.Cos (radian), Mathf.Sin (radian));
	}

	public static Vector2 DegreeToVector2 (float degree) {
		return RadianToVector2 (degree * Mathf.Deg2Rad);
	}

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

	/// <summary>
	/// Wraps a value between 0 (inc) and 360 (exc)
	/// </summary>
	public static float NormalizeDegrees (float degreeValue) {
		float temp = degreeValue;
		while (temp < 0f) {
			temp += 360f;
		}
		while (temp >= 360f) {
			temp -= 360f;
		}
		return temp;
	}
}
