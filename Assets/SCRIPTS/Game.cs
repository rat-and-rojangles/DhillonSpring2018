using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

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
	private Daylight m_daylight;
	public Daylight daylight {
		get { return m_daylight; }
	}

	[SerializeField]
	private TextHeaderForWorldObject m_screenInteractPromptText;
	public TextHeaderForWorldObject screenInteractPromptText {
		get { return m_screenInteractPromptText; }
	}

	[SerializeField]
	private Material m_highlightMaterial;
	public Material highlightMaterial {
		get { return m_highlightMaterial; }
	}

	[SerializeField]
	private ThoughtBubble m_thoughtBubble;
	public ThoughtBubble thoughtBubble {
		get { return m_thoughtBubble; }
	}

	/// <summary>
	/// Set Time.timeScale.
	/// </summary>
	public void SetTimeScale (float newTimeScale) {
		Time.timeScale = newTimeScale;
	}

	public void LockCursor () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	public void UnlockCursor () {
		Cursor.lockState = CursorLockMode.None;
	}

	[SerializeField]
	private UnityEngine.UI.Image m_darknessImage;

	/// <summary>
	/// From 0 - 1, where 0 is normal and 1 is fully black.
	/// </summary>
	public void SetScreenDarkness (float darkness) {
		m_darknessImage.color = Color.black.ChangedAlpha (darkness);
	}

	[SerializeField]
	private PlayerCharacter m_player;
	public PlayerCharacter player {
		get { return m_player; }
	}
}
