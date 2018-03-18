using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortMessageGenerator : MonoBehaviour {
	[SerializeField]
	private Transform mainCanvas;

	[SerializeField]
	private GameObject shortMessagePrefab;

	public void GenerateShortMessage (string message) {
		GameObject shortMessage = Instantiate (shortMessagePrefab);
		shortMessage.transform.SetParent (mainCanvas, false);
		shortMessage.GetComponent<ShortMessage> ().text.text = message;
	}
}
