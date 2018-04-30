using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour {

	[SerializeField]
	private Image darken;
	[SerializeField]
	private GameObject shootButton; //symbolizes life

	[SerializeField]
	private GameObject pressToContinue;
	void Update () {
		if (shootButton.activeSelf && Energy.current.energyRatio <= 0.0000001f) {
			shootButton.SetActive (false);
			StartCoroutine (Die ());
		}
	}

	public IEnumerator Die () {
		if (ImportantAssets.characterPreferences.highScore < NightScore.current.score) {
			ImportantAssets.characterPreferences.highScore = NightScore.current.score;
		}
		Game.current.heroCharacter.gameObject.SetActive (false);
		Timer timer = new Timer (1f);
		StartCoroutine (timer.StartTicking ());
		while (!timer.complete) {
			darken.color = Color.black.ChangedAlpha (timer.ratio);
			yield return null;
		}
		pressToContinue.SetActive (true);
		while (!Input.GetKeyDown (KeyCode.Q)) {
			yield return null;
		}
		SceneManager.LoadScene ("MainMenu");
	}
}
