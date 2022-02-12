using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam2: MonoBehaviour {

	//public float movimento;
	//Camera cam;

	private Vector2 velocidade;
	public float smootTimeY, smootTimeX, deltaY;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		smootTimeY = 0.2f;
		smootTimeX = 0.2f;
		deltaY = 0.4f;
	}

	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){

		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocidade.x, smootTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + deltaY, ref velocidade.y, smootTimeY);
		transform.position = new Vector3 (posX, posY, transform.position.z);



		//	if ((Input.GetKey (KeyCode.D) == true) || (Input.GetKey (KeyCode.RightArrow) == true)) {

		//		 transform.Translate (movimento * Time.deltaTime, 0, 0);

		//	} else if ((Input.GetKey (KeyCode.A) == true) || (Input.GetKey (KeyCode.LeftArrow) == true)) {

		//		transform.Translate (movimento * Time.deltaTime, 0, 0);

		///} else if (Input.GetKey (KeyCode.R) == true) {

		//	transform.Translate ((movimento + 0.2f) * Time.deltaTime, 0, 0);

		//	} else if (Input.GetKey (KeyCode.E) == true) {

		//		transform.Translate ((movimento + 0.2f) * Time.deltaTime, 0, 0);

		//	}

	}
}

