using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	private static Game m_current;
	/// <summary>
	/// Return the Game of the active scene.
	/// </summary>
	public static Game current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
		if (heroCharacter == null) { }	// just make sure it's instantiated
	}

	void Start () {
		// initialize all initializables
		foreach (Initializable i in Utility.FindObjectsOfTypeAll<Initializable> ()) {
			i.Initialize ();
		}
	}

	void OnDestroy () {
		m_current = null;
	}

	[SerializeField]
	private RectTransform m_mainCanvasRect;
	/// <summary>
	/// RectTransform for the main UI canvas.
	/// </summary>
	public RectTransform mainCanvasRect {
		get { return m_mainCanvasRect; }
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
	private DayCharacter m_dayCharacter;
	/// <summary>
	/// User controlled kid for day levels. Null during night levels.
	/// </summary>
	public DayCharacter dayCharacter {
		get { return m_dayCharacter; }
	}


	[SerializeField]
	private HeroInstantiator heroInstantiator;
	private HeroCharacter m_heroCharacter;
	/// <summary>
	/// User controlled hero for night levels. Null during day levels.
	/// </summary>
	public HeroCharacter heroCharacter {
		get {
			if (heroInstantiator == null) {
				return null;
			}
			else if (m_heroCharacter == null) {
				m_heroCharacter = heroInstantiator.InstantiateHero ();
			}
			return m_heroCharacter;
		}
	}
}
