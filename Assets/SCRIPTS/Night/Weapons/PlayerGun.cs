using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour {
	public float recoilScale = 3f;

	public float leadMinDistance = 10f;
	public float leadMaxDistance = 20f;

	private Vector2 camLead = Vector2.zero;

	[SerializeField]
	private GameObject bulletPrefab;
	public void Shoot () {
		Instantiate (bulletPrefab).GetComponent<Bullet> ().Initialize (transform.eulerAngles.z);
		GameNight.staticRef.player.rigidbody2D.velocity += Utility.DegreeToVector2 (transform.eulerAngles.z + 180f).normalized * recoilScale;
		GameNight.staticRef.playerEnergy.IncreaseEnergy (-GameNight.staticRef.player.bulletEnergyCost);
		GameNight.staticRef.completeCameraMain.camShake.Shake (0.5f, 0.1f);
		SoundPlayer.PlayOneShot (GameNight.staticRef.soundLibrary.gunshot, 2f);
	}

	void Update () {

		Vector3 mouseWorldPoint = GameNight.staticRef.completeCameraMain.camera.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * (transform.position.z - GameNight.staticRef.completeCameraMain.camera.transform.position.z));
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

		GameNight.staticRef.completeCameraMain.looseFollow.offset = camLead;
	}
}
