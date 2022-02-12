using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poste2 : MonoBehaviour {

	Light luz;
	float max = 8.79f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator poste1(){
		yield return new WaitForSeconds (50.0f);
		luz.intensity = 0;
		yield return new WaitForSeconds (10.0f);
		luz.intensity = max;
		yield return new WaitForSeconds (10.0f);
		luz.intensity = 0;	
 
	}
}

