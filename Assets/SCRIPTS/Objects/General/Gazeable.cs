using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objects that respond to being looked at by the player.
/// </summary>
public abstract class Gazeable : MonoBehaviour {
	private Renderer p_renderer;
	private Material [] p_originalMaterials;

	private bool m_gazeable = true;
	/// <summary>
	/// Can the object be gazed at?
	/// </summary>
	public bool gazeable {
		get { return m_gazeable; }
		set {
			bool previousGazeState = currentlyInGaze;
			m_gazeable = value;
			UpdateGaze (previousGazeState);
		}
	}
	private bool m_mousedOver = false;
	private bool mousedOver {
		get { return m_mousedOver; }
		set {
			bool previousGazeState = currentlyInGaze;
			m_mousedOver = value;
			UpdateGaze (previousGazeState);
		}
	}

	/// <summary>
	/// Is this object currently in view?
	/// </summary>
	public bool currentlyInGaze {
		get { return gazeable && mousedOver; }
	}

	private void UpdateGaze (bool previousGazeState) {
		if (currentlyInGaze) {
			List<Material> newMats = new List<Material> ();
			Material [] oldMats = p_renderer.materials;
			for (int x = 0; x < oldMats.Length; x++) {
				Material tempHighlight = new Material (ImportantAssets.highlightMaterial);
				tempHighlight.mainTexture = oldMats [x].mainTexture;
				newMats.Add (tempHighlight);
			}
			p_renderer.materials = newMats.ToArray ();
		}
		else {
			p_renderer.materials = p_originalMaterials;
		}

		if (currentlyInGaze && !previousGazeState) {
			OnGazeEnter ();
		}
		else if (!currentlyInGaze && previousGazeState) {
			OnGazeExit ();
		}
	}

	private void OnMouseEnter () {
		if (!mousedOver) {
			mousedOver = true;
		}
	}
	protected void OnMouseExit () {
		if (mousedOver) {
			mousedOver = false;
		}
	}

	protected virtual void OnGazeEnter () { }
	protected virtual void OnGazeExit () { }

	public virtual void Awake () {
		p_renderer = GetComponentInChildren<Renderer> ();
		p_originalMaterials = p_renderer.materials;
	}
}
