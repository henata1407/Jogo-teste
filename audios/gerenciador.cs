using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciador : MonoBehaviour {

	public AudioSource som;
	public static gerenciador inst = null;

	// Use this for initialization
	void Awake () {
		if (inst == null) {
			inst = this;
		} else if (inst != this) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	public void PlayAudio(AudioClip ClipAudio) {

		som.clip = ClipAudio;
		som.Play ();
	}
}
