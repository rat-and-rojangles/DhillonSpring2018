using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNight : MonoBehaviour {

	private static Game m_staticRef;
	/// <summary>
	/// Return the Game of the active scene.
	/// </summary>
	public static Game staticRef {
		get { return m_staticRef; }
	}

	void Awake () {
		m_staticRef = this;
	}

	void Start () {
		// initialize all initializables
		foreach (Initializable i in Utility.FindObjectsOfTypeAll<Initializable> ()) {
			i.Initialize ();
		}
	}

	void OnDestroy () {
		m_staticRef = null;
	}

	[SerializeField]
	private RectTransform m_mainCanvasRect;
	/// <summary>
	/// RectTransform for the main UI canvas.
	/// </summary>
	public RectTransform mainCanvasRect {
		get { return m_mainCanvasRect; }
	}

	[SerializeField]
	private ShortMessageGenerator shortMessageGenerator;
	public void DisplayShortMessage (string message) {
		shortMessageGenerator.GenerateShortMessage (message);
	}

	[SerializeField]
	private HeroCharacter m_player;
	public HeroCharacter player {
		get { return m_player; }
	}
}
