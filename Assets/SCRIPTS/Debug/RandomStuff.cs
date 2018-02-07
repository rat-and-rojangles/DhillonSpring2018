using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStuff : MonoBehaviour {
	public void PrintRandomNumberToOnScreenConsole () {
		OnScreenConsole.Log (Random.value);
	}
	public void ClearOnScreenConsole () {
		OnScreenConsole.ClearConsole ();
	}
	public void RandomizeConsoleColor () {
		OnScreenConsole.textColor = new ColorHSV (Random.value, 1f, 1f, 1f);
		OnScreenConsole.Log ("Hue: " + OnScreenConsole.textColor.ToHSV ().h);
	}
}
