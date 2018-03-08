using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBall : CollectibleItem {
	[SerializeField]
	private Sprite m_icon;
	public override Sprite icon {
		get {
			return m_icon;
		}
	}

	private Rigidbody m_rigidbody;
	private new Rigidbody rigidbody {
		get {
			if (m_rigidbody == null) {
				m_rigidbody = GetComponent<Rigidbody> ();
			}
			return m_rigidbody;
		}
	}

	public override string promptText {
		get { return "Take ball"; }
	}

	public override void Deploy () {
		transform.position = Game.staticRef.player.transform.position + Game.staticRef.player.transform.forward;
		gameObject.SetActive (true);
		rigidbody.AddForce (Game.staticRef.player.transform.forward * 10f + Vector3.up * 2f, ForceMode.VelocityChange);
	}
}
