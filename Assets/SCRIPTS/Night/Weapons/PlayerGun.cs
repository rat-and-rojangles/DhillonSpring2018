using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {

	public float leadMinDistance = 10f;
	public float leadMaxDistance = 20f;

	private Vector2 camLead = Vector2.zero;


	private Camera m_mainCamera = null;
	private Camera mainCamera {
		get {
			if (m_mainCamera == null) {
				m_mainCamera = Camera.main;
			}
			return m_mainCamera;
		}
	}

	private LooseFollow m_looseFollow = null;
	private LooseFollow looseFollow {
		get {
			if (m_looseFollow == null) {
				m_looseFollow = mainCamera.GetComponent<LooseFollow> ();
			}
			return m_looseFollow;
		}
	}


	void Update () {
		Vector3 mouseWorldPoint = mainCamera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * (transform.position.z - mainCamera.transform.position.z));
		Vector3 diff = mouseWorldPoint - transform.position;
		diff.z = 0f;

		Vector3 normalDiff = diff.normalized;
		float rot_z = Mathf.Atan2 (normalDiff.y, normalDiff.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.Euler (0f, 0f, rot_z);

		if (Input.GetMouseButton (1) || Input.GetKey (KeyCode.LeftShift)) {
			float leadFactor = Mathf.Lerp (leadMinDistance, leadMaxDistance, (diff.magnitude - leadMinDistance) / (leadMaxDistance - leadMinDistance)) - leadMinDistance;
			camLead = transform.right * leadFactor;
		}
		else {
			camLead = Vector2.zero;
		}

		looseFollow.offset = camLead;
	}
}
