using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTreasure : MonoBehaviour {

	[SerializeField]
	private Treasure connectedTreasure;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.GetComponent<HeroCharacter> () != null) {
			gameObject.SetActive (false);
			connectedTreasure.Disappear ();
		}
	}

}
