using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCam : MonoBehaviour {

	public AudioSource musicaFundo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Z) == true) {

			musicaFundo.Play ();
			
		} else if (Input.GetKeyDown (KeyCode.X) == true) {

			musicaFundo.Stop ();

		} else if (Input.GetKeyDown (KeyCode.C) == true) {

			musicaFundo.Pause ();
		}
		
	}
}
