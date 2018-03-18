using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : OffscreenUIElement, Initializable {


	private bool disappearing = false;

	private CollectibleItem [] ownedItems = new CollectibleItem [5];
	[SerializeField]
	private BackpackButton [] backpackButtons;

	public void Close () {
		if (!disappearing) {
			Cursor.lockState = CursorLockMode.Locked;
			disappearing = true;
			StartCoroutine (ExitScreen ());
		}
	}

	private IEnumerator ExitScreen () {
		Vector2 initialPosition = rectTransform.anchoredPosition;
		float timeRemaining = transitionTime;
		while (timeRemaining >= 0f) {
			rectTransform.anchoredPosition = Interpolation.Interpolate (offScreenPos, initialPosition, timeRemaining / transitionTime, interpolationMethod);
			timeRemaining -= Time.unscaledDeltaTime;
			yield return null;
		}
		gameObject.SetActive (false);
		Time.timeScale = 1f;
		disappearing = false;
	}

	/// <summary>
	/// Add this item to the backpack.
	/// </summary>
	public void CollectItem (CollectibleItem item) {
		int desiredIndex = -1;
		for (int x = 0; x < ownedItems.Length; x++) {
			if (ownedItems [x] == null) {
				desiredIndex = x;
				x = ownedItems.Length;
			}
		}
		if (desiredIndex == -1) {
			Game.staticRef.thoughtBubble.SetMessage ("My backpack is full!");
		}
		else {
			item.gameObject.SetActive (false);
			ownedItems [desiredIndex] = item;
			Game.staticRef.DisplayShortMessage ("Collected!");
			UpdateButtons ();
		}
	}

	/// <summary>
	/// Use item in backpack at this index.
	/// </summary>
	public void UseItem (int index) {
		if (ownedItems [index] == null) {
			throw new System.NullReferenceException ("This slot in your backpack is currently null.");
		}
		else {
			Close ();
			ownedItems [index].Deploy ();
			ownedItems [index] = null;
			UpdateButtons ();
		}
	}

	private void UpdateButtons () {
		for (int x = 0; x < backpackButtons.Length; x++) {
			backpackButtons [x].UpdateWithData (ownedItems [x]);
		}
	}

	public void Initialize () {
		UpdateButtons ();
	}
}
