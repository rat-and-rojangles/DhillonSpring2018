using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy {

	public float speed;

	private Rigidbody2D m_rigidbody2D;
	private new Rigidbody2D rigidbody2D {
		get {
			if (m_rigidbody2D == null) {
				m_rigidbody2D = GetComponent<Rigidbody2D> ();
			}
			return m_rigidbody2D;
		}
	}

	void FixedUpdate () {
		Vector2 direction = (Game.current.heroCharacter.transform.position - transform.position).normalized;
		rigidbody2D.MovePositionRelative (direction * speed * Time.deltaTime);
		
	}
}
