using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCamera : MonoBehaviour {
	[SerializeField]
	private Camera m_camera;
	public new Camera camera {
		get {
			return m_camera;
		}
	}
	[SerializeField]
	private LooseFollow m_looseFollow;
	public LooseFollow looseFollow {
		get {
			return m_looseFollow;
		}
	}

	[SerializeField]
	private CamShake m_camShake;
	public CamShake camShake {
		get {
			return m_camShake;
		}
	}
}
