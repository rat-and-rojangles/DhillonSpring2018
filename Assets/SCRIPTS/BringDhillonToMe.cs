using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringDhillonToMe : MonoBehaviour {

	public void SetPositionAndRotation () {
		Game.current.dayCharacter.transform.position = transform.position;
		Game.current.dayCharacter.transform.LookAt (transform.position + transform.forward);
	}
}
