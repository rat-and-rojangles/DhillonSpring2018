using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNight : MonoBehaviour {

	private static GameNight m_staticRef;
	/// <summary>
	/// Return the Game of the active scene.
	/// </summary>
	public static GameNight staticRef {
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
	private HeroCharacter m_player;
	public HeroCharacter player {
		get { return m_player; }
	}

	[SerializeField]
	private Energy m_playerEnergy;
	public Energy playerEnergy {
		get { return m_playerEnergy; }
	}

	[SerializeField]
	private CompleteCamera m_completeCameraMain;
	public CompleteCamera completeCameraMain {
		get {
			return m_completeCameraMain;
		}
	}

	[SerializeField]
	private SoundLibrary m_soundLibrary;
	public SoundLibrary soundLibrary{
		get{
			return  m_soundLibrary;
		}
	}

	[SerializeField]
	private NightScore m_score;
	public NightScore score{
		get{
			return  m_score;
		}
	}
}
