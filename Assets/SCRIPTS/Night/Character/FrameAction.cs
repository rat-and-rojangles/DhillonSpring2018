using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All of the things a player can do per frame.
/// </summary>
public class FrameAction {
	public int moveDirection;
	public bool jump;

	public FrameAction (int moveDirection, bool jump) {
		this.moveDirection = moveDirection;
		this.jump = jump;
	}

	/// <summary>
	/// Overwrites movements, ORs jump
	/// </summary>
	public void CombineWith (FrameAction other) {
		moveDirection = other.moveDirection;
		jump = jump || other.jump;
	}

	/// <summary>
	/// Sets this to a neutral action. No movement, no jump.
	/// </summary>
	public void Clear () {
		moveDirection = 0;
		jump = false;
	}

	/// <summary>
	/// Overwrites movements, ORs jump
	/// </summary>
	public FrameAction Combined (FrameAction other) {
		return new FrameAction (other.moveDirection, jump || other.jump);
	}

	public static FrameAction NEUTRAL {
		get { return new FrameAction (0, false); }
	}
}
