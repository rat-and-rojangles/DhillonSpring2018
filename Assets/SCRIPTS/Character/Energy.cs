using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour {

	[SerializeField]
	private float m_maxEnergy;
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

	/// <summary>
	/// Increase Dhillon's energy by this much.
	/// </summary>
	public void IncreaseEnergy (float increaseAmount) {
		currentEnergy += increaseAmount;
	}

	/// <summary>
	/// Reduce Dhillon's energy by this much.
	/// </summary>
	public void DecreaseEnergy (float decreaseAmount) {
		currentEnergy += decreaseAmount;
	}

#if UNITY_EDITOR
	[SerializeField]
	[Range (0f, 1f)]
	private float DEBUG_energyRatio;

	void Update () {
		currentEnergy = maxEnergy * DEBUG_energyRatio;
	}
#endif

}
