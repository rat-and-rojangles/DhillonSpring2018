using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpandStart : MonoBehaviour {
	[TextArea (3, 10)]
	public string message;
	// Use this for initialization
	void Start () {
		Game.staticRef.thoughtBubble.SetMessage (message);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
