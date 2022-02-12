using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		StartCoroutine (PulaCena ());
	}

	IEnumerator PulaCena(){
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("menu");
	}
}