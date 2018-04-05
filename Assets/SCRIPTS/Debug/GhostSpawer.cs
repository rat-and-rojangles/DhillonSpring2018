using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawer : MonoBehaviour {

	public GameObject prefab;

	public void Spawn () {
		Vector3 offset = Random.insideUnitCircle.normalized * 10f;
		Instantiate (prefab, Game.current.heroCharacter.transform.position + offset, Quaternion.identity);
	}
}
