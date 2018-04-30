using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTriggerEnter : MonoBehaviour {
	public LayerMask layerMask;
	public UnityEvent onTriggerEnter;

	void OnTriggerEnter (Collider other) {
		if (layerMask.Contains (other.gameObject.layer)) {
			onTriggerEnter.Invoke ();
		}
	}
}
