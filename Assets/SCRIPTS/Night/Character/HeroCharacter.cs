using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : MonoBehaviour {

	[SerializeField]
	private LayerMask groundMask;

	private ControlCharacter controller;
	private Rigidbody2D m_rigidbody2D;
	public new Rigidbody2D rigidbody2D {
		get {
			if (m_rigidbody2D == null) {
				m_rigidbody2D = GetComponent<Rigidbody2D> ();
			}
			return m_rigidbody2D;
		}
	}
	private new BoxCollider2D collider;

	public float timeSinceLastJump = 0f;

	private Vector2 groundCheckPointLeftLocal;
	private Vector2 groundCheckPointRightLocal;
	public bool grounded {
		get {
			Collider2D leftCollision = Physics2D.OverlapPoint (transform.TransformPoint (groundCheckPointLeftLocal), groundMask);
			Collider2D rightCollision = Physics2D.OverlapPoint (transform.TransformPoint (groundCheckPointRightLocal), groundMask);
			return leftCollision != null | rightCollision != null;
		}
	}

	private SpriteRenderer spriteRenderer;
	public Color color {
		get { return spriteRenderer.color; }
		set { spriteRenderer.color = value; }
	}

	public float runSpeed = 1f;
	public float jumpHeight = 4f;
	public int extraJumps = 1;
	private int remainingJumps = 0;

	/// <summary>
	/// Cuts run speed and jump height.
	/// </summary>
	public bool weakened = false;

	private float derivedRunSpeed {
		get {
			return weakened ? runSpeed * 0.5f : runSpeed;
		}
	}
	private float derivedJumpVelocity {
		get {
			float maxJumpVel = Mathf.Sqrt (2f * jumpHeight * -Physics2D.gravity.y * rigidbody2D.gravityScale);
			if (weakened) {
				maxJumpVel *= 0.75f;
			}
			return maxJumpVel;
		}
	}

	public Vector2 velocity {
		get { return rigidbody2D.velocity; }
	}

	public bool dead {
		get { return !enabled; }
	}

	private FrameAction actions;


	void Start () {
		controller = new ControlCharacterHuman ();

		spriteRenderer = GetComponent<SpriteRenderer> ();
		collider = GetComponent<BoxCollider2D> ();
		groundCheckPointLeftLocal = collider.offset + Vector2.down * collider.size.y * 0.55f + Vector2.left * collider.size.x * 0.5f;
		groundCheckPointRightLocal = collider.offset + Vector2.down * collider.size.y * 0.55f + Vector2.right * collider.size.x * 0.5f;
	}

	void Update () {
		timeSinceLastJump += Time.deltaTime;
		actions = actions.Combined (controller.GetActions ());
	}

	void FixedUpdate () {
		if (grounded) {
			remainingJumps = extraJumps;
		}

		if (actions.moveDirection == 0) {
			rigidbody2D.SetVelocity (new Vector2 (Mathf.Lerp (velocity.x, 0f, 5f * Time.fixedDeltaTime), velocity.y));
		}
		else {
			rigidbody2D.SetVelocity (new Vector2 (derivedRunSpeed * actions.moveDirection, velocity.y));
		}

		if (actions.jump) {
			if (grounded) {
				Jump ();
				SoundPlayer.PlayOneShot (GameNight.staticRef.soundLibrary.jump1);
			}
			else if (remainingJumps > 0) {
				remainingJumps--;
				Jump ();
				SoundPlayer.PlayOneShot (GameNight.staticRef.soundLibrary.jump2);
			}
		}
		actions = FrameAction.NEUTRAL;
	}

	private void Jump () {
		rigidbody2D.SetVelocity (new Vector2 (velocity.x, derivedJumpVelocity));
		timeSinceLastJump = 0f;
	}
}
