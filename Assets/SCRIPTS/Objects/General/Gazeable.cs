using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objects that respond to being looked at by the player.
/// </summary>
public abstract class Gazeable : MonoBehaviour {
	private bool p_currentlyInGaze = false;
	private Renderer p_renderer;
	private Material [] p_originalMaterials;

	/// <summary>
	/// Is this object currently in view?
	/// </summary>
	public bool currentlyInGaze {
		get { return p_currentlyInGaze; }
	}

	private void OnMouseEnter () {
		if (!currentlyInGaze) {
			p_currentlyInGaze = true;
			List<Material> newMats = new List<Material> ();
			Material [] oldMats = p_renderer.materials;
			for (int x = 0; x < oldMats.Length; x++) {
				Material tempHighlight = new Material (Game.staticRef.highlightMaterial);
				tempHighlight.mainTexture = oldMats [x].mainTexture;
				newMats.Add (tempHighlight);
			}
			p_renderer.materials = newMats.ToArray ();
			OnGazeEnter ();
		}
	}
	protected void OnMouseExit () {
		if (currentlyInGaze) {
			p_currentlyInGaze = false;
			p_renderer.materials = p_originalMaterials;
			OnGazeExit ();
		}
	}
	protected virtual void OnGazeEnter () { }
	protected virtual void OnGazeExit () { }

	public virtual void Awake () {
		p_renderer = GetComponent<Renderer> ();
		p_originalMaterials = p_renderer.materials;
	}
}
