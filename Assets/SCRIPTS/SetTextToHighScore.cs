using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextToHighScore : MonoBehaviour, Initializable {


	public void Initialize () {
		Apply ();
	}

	void Start () {
		Apply ();
	}

	private void Apply () {
		GetComponent<UnityEngine.UI.Text> ().text = "Hero High Score: " + ImportantAssets.characterPreferences.highScore;
	}
}
