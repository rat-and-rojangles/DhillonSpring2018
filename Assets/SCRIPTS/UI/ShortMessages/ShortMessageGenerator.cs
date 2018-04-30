using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortMessageGenerator : MonoBehaviour {

	public float queueTime = 0.25f;

	private static ShortMessageGenerator m_current;
	/// <summary>
	/// Return the ShortMessageGenerator of the active scene.
	/// </summary>
	public static ShortMessageGenerator current {
		get { return m_current; }
	}

	private class MessageContainer {
		public string message;
		public HealthCategory healthCategory;
		public MessageContainer (string message, HealthCategory healthCategory) {
			this.message = message;
			this.healthCategory = healthCategory;
		}
	}

	private Queue<MessageContainer> messageQueue;
	private Timer timer;

	void Awake () {
		messageQueue = new Queue<MessageContainer> ();
		timer = new Timer (-1f);
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	private void LaunchFirstMessage () {
		MessageContainer messageContainer = messageQueue.Dequeue ();
		GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		if (Game.current.heroCharacter != null) {
			Vector2 viewportPos = CompleteCamera.current.camera.WorldToViewportPoint (Game.current.heroCharacter.transform.position);
			(shortMessage.transform as RectTransform).anchoredPosition = new Vector2 (((viewportPos.x * Game.current.mainCanvasRect.sizeDelta.x) - (Game.current.mainCanvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * Game.current.mainCanvasRect.sizeDelta.y) - (Game.current.mainCanvasRect.sizeDelta.y * 0.5f)));
		}
		shortMessage.GetComponent<ShortMessage> ().Setup (messageContainer.message, messageContainer.healthCategory);
	}

	public void GenerateShortMessage (string message, HealthCategory healthCategory) {
		// GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		// shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		// shortMessage.GetComponent<ShortMessage> ().Setup (message, healthCategory);
		messageQueue.Enqueue (new MessageContainer (message, healthCategory));
	}

	public void GenerateShortMessage (string message) {
		// GameObject shortMessage = Instantiate (ImportantAssets.shortMessagePrefab);
		// shortMessage.transform.SetParent (Game.current.mainCanvasRect, false);
		// if (Game.current.heroCharacter != null) {
		// 	Vector2 viewportPos = CompleteCamera.current.camera.WorldToViewportPoint (Game.current.heroCharacter.transform.position);
		// 	(shortMessage.transform as RectTransform).anchoredPosition = new Vector2 (((viewportPos.x * Game.current.mainCanvasRect.sizeDelta.x) - (Game.current.mainCanvasRect.sizeDelta.x * 0.5f)), ((viewportPos.y * Game.current.mainCanvasRect.sizeDelta.y) - (Game.current.mainCanvasRect.sizeDelta.y * 0.5f)));
		// }
		// shortMessage.GetComponent<ShortMessage> ().Setup (message, HealthCategory.Uncategorized);
		GenerateShortMessage (message, HealthCategory.Uncategorized);
	}

	void Update () {
		if (timer.complete && messageQueue.Count > 0) {
			LaunchFirstMessage ();
			timer = new Timer (queueTime);
			StartCoroutine (timer.StartTicking ());
		}
	}

}
