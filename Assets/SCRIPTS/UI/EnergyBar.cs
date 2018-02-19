using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour {

	private float maxHeight;

	private Color maxColor = Color.Lerp (Color.white, Color.yellow, 0.5f);

	[SerializeField]
	private Image barImage;

	void Start () {
		maxHeight = barImage.rectTransform.sizeDelta.y;
	}

	void Update () {
		UpdateUI (Game.staticRef.player.energy.energyRatio);
	}


	private void UpdateUI (float ratio) {
		barImage.rectTransform.sizeDelta = new Vector2 (barImage.rectTransform.sizeDelta.x, maxHeight * ratio);
		barImage.color = Color.Lerp (Color.black, maxColor, ratio);
	}
}
