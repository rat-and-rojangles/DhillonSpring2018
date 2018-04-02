using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {
	public static void SetVelocity (this Rigidbody2D rigidbody2D, Vector2 velocity) {
		rigidbody2D.velocity += -rigidbody2D.velocity + velocity;
	}

	public static void MovePositionRelative (this Rigidbody2D rigidbody2D, Vector2 increment) {
		rigidbody2D.MovePosition (rigidbody2D.position + increment);
	}

	/// <summary>
	/// untested
	/// </summary>
	public static void Rotate (this Vector2 vector, float angleDegrees) {
		float angleRadians = angleDegrees * Mathf.Deg2Rad;
		vector.Set (Mathf.Cos (angleRadians) * vector.x - Mathf.Sin (angleRadians) * vector.y, Mathf.Sin (angleRadians) * vector.x + Mathf.Cos (angleRadians) * vector.y);
	}
}
