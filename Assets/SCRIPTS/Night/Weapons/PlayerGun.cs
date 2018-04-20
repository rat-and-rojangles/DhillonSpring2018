using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {
	public float recoilScale = 3f;

	public float leadMinDistance = 10f;
	public float leadMaxDistance = 20f;

	private Vector2 camLead = Vector2.zero;

	public float deadZoneDegreeRadius = 25f;
	/// <summary>
	/// Returns 1 if pointed right, -1 if left, and 0 if in dead zone (straight up or down)
	/// </summary>
	/// <returns></returns>
	public int trinaryTiltDirection {
		get {
			float degreez = Utility.NormalizeDegrees (transform.rotation.eulerAngles.z);
			if (degreez > 270 + deadZoneDegreeRadius || degreez.Between (0f, 90f - deadZoneDegreeRadius)) {
				return 1;
			}
			else if (degreez.Between (90f + deadZoneDegreeRadius, 270f - deadZoneDegreeRadius)) {
				return -1;
			}
			else {
				return 0;
			}
		}
	}

	[SerializeField]
	private GameObject bulletPrefab;
	public void Shoot () {
		Instantiate (bulletPrefab).GetComponent<Bullet> ().Initialize (transform.eulerAngles.z);
		Game.current.heroCharacter.rigidbody2D.velocity += Utility.DegreeToVector2 (transform.eulerAngles.z + 180f).normalized * recoilScale;
		Energy.current.IncreaseEnergySilently (-Game.current.heroCharacter.bulletEnergyCost);
		CompleteCamera.current.camShake.Shake (0.5f, 0.1f);
		SoundPlayer.PlayOneShot (ImportantAssets.soundLibrary.gunshot, 2f);
	}

	void Update () {

		Vector3 mouseWorldPoint = CompleteCamera.current.camera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * (transform.position.z - CompleteCamera.current.camera.transform.position.z));
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

		CompleteCamera.current.looseFollow.offset = camLead;
	}
}
