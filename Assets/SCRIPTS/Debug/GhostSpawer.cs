using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawer : MonoBehaviour {

	public GameObject prefab;
	public float timeBetweenSpawns = 3f;
	public float spawnDistanceFromHero = 10f;
	public float distanceTimeReductionFactor = 0.05f;

	private float remainingTimeUntilSpawn;
	private Vector3 lastSpawnCharacterPosition;

	void Start () {
		remainingTimeUntilSpawn = 0f;
		lastSpawnCharacterPosition = Game.current.heroCharacter.transform.position;
	}

	void LateUpdate () {
		remainingTimeUntilSpawn -= Time.deltaTime * Vector3.Distance (lastSpawnCharacterPosition, Game.current.heroCharacter.transform.position);
		if (remainingTimeUntilSpawn <= 0f) {
			Spawn ();
			remainingTimeUntilSpawn = timeBetweenSpawns + Utility.randomMagnitude * timeBetweenSpawns * 0.25f;
			lastSpawnCharacterPosition = Game.current.heroCharacter.transform.position;
		}
	}

	public void Spawn () {
		Vector3 offset = Random.insideUnitCircle.normalized * spawnDistanceFromHero;
		Instantiate (prefab, Game.current.heroCharacter.transform.position + offset, Quaternion.identity);
	}
}
