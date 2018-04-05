using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCamera : MonoBehaviour {
	private static CompleteCamera m_current;
	/// <summary>
	/// Return the CompleteCamera of the active scene.
	/// </summary>
	public static CompleteCamera current {
		get { return m_current; }
	}
	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	[SerializeField]
	private Camera m_camera;
	/// <summary>
	/// Main camera. More efficient than Camera.main.
	/// </summary>
	public new Camera camera {
		get {
			return m_camera;
		}
	}
	[SerializeField]
	private LooseFollow2D m_looseFollow;
	/// <summary>
	/// LooseFollow. Null during the day.
	/// </summary>
	public LooseFollow2D looseFollow {
		get {
			return m_looseFollow;
		}
	}

	[SerializeField]
	private CamShake m_camShake;
	/// <summary>
	/// CamShake
	/// </summary>
	public CamShake camShake {
		get {
			return m_camShake;
		}
	}
}
