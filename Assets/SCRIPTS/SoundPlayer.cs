using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	private AudioSource audioSource;

	private static SoundPlayer m_staticRef = null;
	private static SoundPlayer staticRef {
		get {
			if (m_staticRef == null) {
				GameObject empty = new GameObject ("On Screen Console");
				m_staticRef = empty.AddComponent<SoundPlayer> ();
				m_staticRef.audioSource = empty.AddComponent<AudioSource> ();
			}
			return m_staticRef;
		}
	}

	void OnDestroy () {
		m_staticRef = null;
	}

	public static void PlayOneShot (AudioClip clip) {
		PlayOneShot (clip, 1f);
	}
	public static void PlayOneShot (AudioClip clip, float volumeScale) {
		if (clip == null) {
			throw new System.NullReferenceException ("Cannot play null audio clip");
		}
		staticRef.audioSource.PlayOneShot (clip, volumeScale);
	}
}
