using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {
	public static void SetVelocity (this Rigidbody2D rigidbody2D, Vector2 velocity) {
		rigidbody2D.velocity += -rigidbody2D.velocity + velocity;
	}
}
