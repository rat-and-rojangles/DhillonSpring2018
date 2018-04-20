using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CHARACTER MUST BE FACING RIGHT BY DEFAULT
/// </summary>
public class HeroAnimationController : MonoBehaviour {

	[SerializeField]
	private Animator animator;

	private Quaternion facingRight;
	private Quaternion facingLeft;

	private float velocityDeadZone = 0.01f;

	private HeroCharacter m_hero = null;
	public HeroCharacter hero {
		get {
			if (m_hero == null) {
				m_hero = GetComponent<HeroCharacter> ();
			}
			return m_hero;
		}
	}

	void Awake () {
		facingRight = animator.transform.rotation;
		facingLeft = Quaternion.Euler (animator.transform.eulerAngles + Vector3.up * 180f);
	}

	public void Update () {
		int gunDirection = hero.gun.trinaryTiltDirection.Sign ();
		int moveDirection = hero.frameAction.moveDirection.Sign ();
		if (gunDirection > 0) {
			animator.transform.rotation = facingRight;
		}
		else if (gunDirection < 0) {
			animator.transform.rotation = facingLeft;
		}
		if (hero.grounded) {
			if (hero.frameAction.moveDirection != 0) {
				if (gunDirection == moveDirection) {
					animator.Play ("RunForward");
				}
				else {
					animator.Play ("RunBackward");
				}

			}
			else {
				animator.Play ("Standing");
			}
		}
		else {
			if (hero.velocity.y > velocityDeadZone) {
				animator.Play ("Rising");
			}
			else {
				animator.Play ("Falling");
			}
		}
	}
}
