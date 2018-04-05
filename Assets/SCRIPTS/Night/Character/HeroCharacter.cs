using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCharacter : MonoBehaviour {

	public float bulletEnergyCost = 1f;
	public float hitDamage = 2f;

	public float stunTime = 1f;
	private float stunTimeRemaining = 0f;

	[SerializeField]
	private LayerMask groundMask;

	private const int NORMAL_LAYER = 13;
	private const int STUNNED_LAYER = 11;

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

	[SerializeField]
	private PlayerGun m_gun;
	public PlayerGun gun {
		get { return m_gun; }
	}

	[SerializeField]
	private MeshRenderer meshRenderer;

	private Vector2 groundCheckPointLeftLocal;
	private Vector2 groundCheckPointRightLocal;
	public bool grounded {
		get {
			Collider2D leftCollision = Physics2D.OverlapPoint (transform.TransformPoint (groundCheckPointLeftLocal), groundMask);
			Collider2D rightCollision = Physics2D.OverlapPoint (transform.TransformPoint (groundCheckPointRightLocal), groundMask);
			return leftCollision != null | rightCollision != null;
		}
	}

	private MovementType movementType = MovementType.Normal;
	private enum MovementType {
		Normal, Stunned, Dashing
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

	public FrameAction frameAction;

	private void UpdateFrameAction () {
		FrameAction thisFrame = new FrameAction (Mathf.RoundToInt (Input.GetAxis ("Horizontal")), Input.GetButtonDown ("Jump") || (Input.GetButtonDown ("Vertical") && Input.GetAxis ("Vertical") > 0f));
		frameAction.CombineWith (thisFrame);
	}

	void Start () {
		frameAction = FrameAction.NEUTRAL;
		collider = GetComponent<BoxCollider2D> ();

		groundCheckPointLeftLocal = collider.offset + Vector2.down * collider.size.y * 0.55f + Vector2.left * collider.size.x * 0.5f;
		groundCheckPointRightLocal = collider.offset + Vector2.down * collider.size.y * 0.55f + Vector2.right * collider.size.x * 0.5f;
	}

	void Update () {
		UpdateFrameAction ();
	}

	void FixedUpdate () {
		if (grounded) {
			remainingJumps = extraJumps;
		}

		switch (movementType) {
			case MovementType.Normal:
				MoveNormal ();
				break;
			case MovementType.Stunned:

				// meshRenderer.material.color = meshRenderer.material.color.ChangedAlpha (Mathf.Lerp (0.25f, 0.75f, (Mathf.Sin ((Time.time) / stunTime * 2f * 0.5f * Mathf.PI) + 1f) * 0.5f));
				stunTimeRemaining -= Time.deltaTime;
				if (stunTimeRemaining <= stunTime * 0.75f) {
					// weakened = false;
					MoveNormal ();
				}

				if (stunTimeRemaining <= 0f) {
					movementType = MovementType.Normal;
					meshRenderer.material.color = meshRenderer.material.color.ChangedAlpha (1f);
					gameObject.layer = NORMAL_LAYER;
					weakened = false;
				}
				break;
			case MovementType.Dashing:
				MoveNormal ();
				break;
		}

		frameAction.Clear ();
	}

	private void Jump () {
		rigidbody2D.SetVelocity (new Vector2 (velocity.x, derivedJumpVelocity));
	}

	private void MoveNormal () {
		if (frameAction.moveDirection == 0) {
			rigidbody2D.SetVelocity (new Vector2 (Mathf.Lerp (velocity.x, 0f, 5f * Time.fixedDeltaTime), velocity.y));
		}
		else {
			rigidbody2D.SetVelocity (new Vector2 (derivedRunSpeed * frameAction.moveDirection, velocity.y));
		}

		if (frameAction.jump) {
			if (grounded) {
				Jump ();
				SoundPlayer.PlayOneShot (ImportantAssets.soundLibrary.jump1);
			}
			else if (remainingJumps > 0) {
				remainingJumps--;
				Jump ();
				SoundPlayer.PlayOneShot (ImportantAssets.soundLibrary.jump2);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy> ();
		if (enemy != null) {
			Energy.current.IncreaseEnergyUncategorized (-hitDamage);
			CompleteCamera.current.camShake.Shake (0.25f, 0.5f);
			meshRenderer.material.color = meshRenderer.material.color.ChangedAlpha (0.25f);
			SoundPlayer.PlayOneShot (ImportantAssets.soundLibrary.hurt);
			movementType = MovementType.Stunned;
			gameObject.layer = STUNNED_LAYER;
			Vector2 stunFling = (transform.position - other.gameObject.transform.position).normalized;
			stunFling.y = 1f;
			rigidbody2D.velocity = stunFling * 15f;
			stunTimeRemaining = stunTime;
		}
	}
}
