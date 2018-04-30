using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaglineSceneController : MonoBehaviour {
	[SerializeField]
	private UnityEngine.UI.InputField field;
	public void SwitchToHeroIntro () {
		if (field.text.Length > 0) {
			ImportantAssets.characterPreferences.playerName = field.text;
			SceneManager.LoadScene ("HumanCustomizer");
		}
	}
}
