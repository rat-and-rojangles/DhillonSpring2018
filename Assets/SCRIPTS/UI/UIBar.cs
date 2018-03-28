using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

	[SerializeField]
	private Vector2 minSize;
	[SerializeField]
	private Vector2 maxSize;

	public Color minColor;
	public Color maxColor;

	[SerializeField]
	private Image barImage;

	[SerializeField]
	[Tooltip ("The ratio at start.")]
	private float m_ratio;
	public float ratio {
		get {
			return m_ratio;
		}
		set {
			m_ratio = Mathf.Clamp (value, 0f, 1f);
		}
	}

	void Update () {
		barImage.rectTransform.sizeDelta = Vector2.Lerp (minSize, maxSize, ratio);
		barImage.color = Color.Lerp (minColor, maxColor, ratio);
	}

	[ContextMenu ("Set Min Size")]
	void SetMinSize () {
		minSize = barImage.rectTransform.sizeDelta;
	}
	[ContextMenu ("Set Max Size")]
	void SetMaxSize () {
		maxSize = barImage.rectTransform.sizeDelta;
	}
	[ContextMenu ("Snap To Min Size")]
	void SnapToMinSize () {
		barImage.rectTransform.sizeDelta = minSize;
	}
	[ContextMenu ("Snap To Max Size")]
	void SnapToMaxSize () {
		barImage.rectTransform.sizeDelta = maxSize;
	}

}
