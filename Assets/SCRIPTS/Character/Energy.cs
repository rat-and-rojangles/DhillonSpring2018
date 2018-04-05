using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	private static Energy m_current;
	/// <summary>
	/// Return the Energy of the active scene.
	/// </summary>
	public static Energy current {
		get { return m_current; }
	}

	void Awake () {
		m_current = this;
	}
	void OnDestroy () {
		m_current = null;
	}

	[SerializeField]
	private float m_maxEnergy = 100f;
	/// <summary>
	/// Dhillon's energy caps out at this value.
	/// </summary>
	public float maxEnergy {
		get { return m_maxEnergy; }
	}
	/// <summary>
	/// How much energy does Dhillon start the level with?
	/// </summary>
	[Range (0f, 1f)]
	[SerializeField]
	private float startingEnergyRatio;

	[SerializeField]
	private UIBar barToUpdate;

	private float m_currentEnergy;
	/// <summary>
	/// Current energy value. Assignment auto clamps.
	/// </summary>
	private float currentEnergy {
		get {
			return m_currentEnergy;
		}
		set {
			m_currentEnergy = Mathf.Clamp (value, 0f, maxEnergy);
		}
	}

	public float energyRatio {
		get {
			return currentEnergy / maxEnergy;
		}
	}

	void Start () {
		m_currentEnergy = maxEnergy * startingEnergyRatio;
	}

	void Update () {
		if (barToUpdate != null) {
			barToUpdate.ratio = energyRatio;
		}
	}

	/// <summary>
	/// Increase Dhillon's energy by this much. Use a negative number to decrease.
	/// </summary>
	public void IncreaseEnergy (float increaseAmount) {
		currentEnergy += increaseAmount;
	}
}
