using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantEnergyDecrease : MonoBehaviour {

	public float drainPerSecond;

	void Update () {
		Energy.current.IncreaseEnergy (-drainPerSecond * Time.deltaTime);
	}
}
