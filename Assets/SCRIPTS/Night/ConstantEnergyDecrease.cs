using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantEnergyDecrease : MonoBehaviour {

	public float drainPerSecond;

	void Update () {
		GameNight.staticRef.playerEnergy.IncreaseEnergy (-drainPerSecond * Time.deltaTime);
	}
}
