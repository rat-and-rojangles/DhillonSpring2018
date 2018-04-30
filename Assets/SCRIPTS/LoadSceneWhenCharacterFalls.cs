using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneWhenCharacterFalls : MonoBehaviour {

	private bool waiting = true;
	void Update () {
		if (waiting && Game.current.heroCharacter.transform.position.y < -30f) {
			waiting = false;
			StartCoroutine (FadeOut ());
		}
	}

	[SerializeField]
	private Image darken;

	[SerializeField]
	private Text seeYouTonight;

	private IEnumerator FadeOut () {
		Timer timer = new Timer (2f);
		StartCoroutine (timer.StartTicking ());
		seeYouTonight.gameObject.SetActive (true);
		while (!timer.complete) {
			darken.color = Color.black.ChangedAlpha (timer.ratio);
			seeYouTonight.transform.localScale = Vector3.one * timer.ratio;
			yield return null;
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene ("HomeScene");
	}
}
