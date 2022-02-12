using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poste1 : MonoBehaviour {

	public Light luz;
	//float max = 8.79f;

	// Use this for initialization
	void Start () {
		luz = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (poste1());
	}
		

	IEnumerator poste1(){
		yield return new WaitForSeconds (1.0f);
		luz.intensity = 0.0f;
		yield return new WaitForSeconds (2.0f);
		luz.intensity = 50.0f;
		yield return new WaitForSeconds (3.0f);
		luz.intensity = 0.0f;	
		yield return new WaitForSeconds (4.0f);
		luz.intensity = 50.0f;
		yield return new WaitForSeconds (5.0f);
		luz.intensity = 0.0f; 
	}


}
