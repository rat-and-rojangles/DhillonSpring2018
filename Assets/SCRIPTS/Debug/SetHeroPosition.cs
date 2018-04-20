using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeroPosition : MonoBehaviour {

	public Vector3 position;

	public void ApplyPosition () {
		Game.current.heroCharacter.transform.position = position;
	}
}
