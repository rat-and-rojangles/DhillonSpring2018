using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpandStart : MonoBehaviour {
	[TextArea (3, 10)]
	public string message;
	
	void Start () {
		ThoughtBubble.current.SetMessage (message);
	}
}
