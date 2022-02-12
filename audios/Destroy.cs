using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	float tempo = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		tempo -= Time.deltaTime;
		if (tempo <= 0) {
			Destroy (gameObject);
		}
	}
}
