using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

	public static bool ValidIndex<T> (this T [] array, int index) {
		return index >= 0 && index < array.Length;
	}

	public static void SetVelocity (this Rigidbody2D rigidbody2D, Vector2 velocity) {
		rigidbody2D.velocity += -rigidbody2D.velocity + velocity;
	}

	public static void MovePositionRelative (this Rigidbody2D rigidbody2D, Vector2 increment) {
		rigidbody2D.MovePosition (rigidbody2D.position + increment);
	}

	public static HealthCategoryResources.HealthCategoryData GetData (this HealthCategory healthCategory) {
		return ImportantAssets.healthCategoryResources.GetDataFromCategory (healthCategory);
	}

	/// <summary>
	/// I'm not sure if this even works, but it seems to.
	/// </summary>
	public static void Rotate (this Vector2 vector, float angleDegrees) {
		float angleRadians = angleDegrees * Mathf.Deg2Rad;
		vector.Set (Mathf.Cos (angleRadians) * vector.x - Mathf.Sin (angleRadians) * vector.y, Mathf.Sin (angleRadians) * vector.x + Mathf.Cos (angleRadians) * vector.y);
	}

	/// <summary>
	/// Returns the sign of the float as -1, 0, or 1.
	/// </summary>
	public static int Sign (this float f) {
		if (f == 0f) {
			return 0;
		}
		else if (f > 0f) {
			return 1;
		}
		else {
			return -1;
		}
	}
	/// <summary>
	/// Returns the sign of the int as -1, 0, or 1.
	/// </summary>
	public static int Sign (this int i) {
		if (i == 0) {
			return 0;
		}
		else if (i > 0) {
			return 1;
		}
		else {
			return -1;
		}
	}
	/// <summary>
	/// Is the value between the min and max? (inclusive)
	/// </summary>
	public static bool Between (this float f, float min, float max) {
		if (min > max) {
			return false;
		}
		else {
			return f >= min && f <= max;
		}
	}
}
