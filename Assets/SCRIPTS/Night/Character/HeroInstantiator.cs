using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInstantiator : MonoBehaviour {

	public HeroCharacter InstantiateHero () {
		GameObject clone = Instantiate (ImportantAssets.heroPrefabs [ImportantAssets.characterPreferences.heroModelIndex]);
		clone.transform.position = transform.position;
		return clone.GetComponent<HeroCharacter> ();
	}
}
