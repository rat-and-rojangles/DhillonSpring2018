using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootButton : MonoBehaviour {

	public void Shoot () {
		Game.current.heroCharacter.gun.Shoot ();
	}
}
