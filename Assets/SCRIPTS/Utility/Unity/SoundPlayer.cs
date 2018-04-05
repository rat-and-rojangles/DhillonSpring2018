using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

	private AudioSource audioSource;

	private static SoundPlayer m_current = null;
	private static SoundPlayer current {
		get {
			if (m_current == null) {
				GameObject empty = new GameObject ("On Screen Console");
				m_current = empty.AddComponent<SoundPlayer> ();
				m_current.audioSource = empty.AddComponent<AudioSource> ();
			}
			return m_current;
		}
	}

	void OnDestroy () {
		m_current = null;
	}

	public static void PlayOneShot (AudioClip clip) {
		PlayOneShot (clip, 1f);
	}
	public static void PlayOneShot (AudioClip clip, float volumeScale) {
		if (clip == null) {
			throw new System.NullReferenceException ("Cannot play null audio clip");
		}
		current.audioSource.PlayOneShot (clip, volumeScale);
	}
}
