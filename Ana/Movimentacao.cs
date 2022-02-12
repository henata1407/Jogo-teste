using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Movimentacao : MonoBehaviour {

	Animator Ana;
	bool botao_mouse;
	int travel;
	int scrollSpeed = 3;
	public float movimento;
	public float velPulo;
	bool pulo;// verifica se há colisão com um objeto para o pulo acontecer
	Rigidbody2D personagemAna;


	// Use this for initialization
	void Start () {

		pulo = false;
		Ana = GetComponent<Animator> ();
		personagemAna = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void FixedUpdate () {
		//
		var d = Input.GetAxis("Mouse ScrollWheel");
		if (d > 0f && travel > -30)
		{
			travel = travel - scrollSpeed;
			transform.Translate(0, 1 * scrollSpeed, 0, Space.Self);
		}
		else if (d < 0f && travel < 100)
		{
			travel = travel + scrollSpeed;
			transform.Translate(0, -1 * scrollSpeed, 0, Space.Self);
		}
		//

		if ((Input.GetKey (KeyCode.D) == true) || (Input.GetKey (KeyCode.RightArrow) == true)) {
			
			//transform.Translate (movimento*Time.deltaTime, 0, 0); //funciona sem a definição Ana -> RigidBody
			personagemAna.transform.Translate (movimento*Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 1);

		} else if ((Input.GetKey (KeyCode.A) == true) || (Input.GetKey (KeyCode.LeftArrow) == true)) {
			
			personagemAna.transform.Translate (movimento*Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 180);
			Ana.SetInteger ("transicao", 1);
			//transform.Rotate (0, 90, 0);

		} else if (((Input.GetKeyDown (KeyCode.W) == true) || (Input.GetKeyDown (KeyCode.UpArrow) == true)||(Input.GetKeyDown(KeyCode.Space)))&& pulo == true) {
	
			personagemAna.AddForce (Vector2.up * velPulo, ForceMode2D.Impulse);
			personagemAna.transform.Translate (0, movimento*Time.deltaTime, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 3);		

		} else if ((Input.GetKeyDown (KeyCode.S) == true) || (Input.GetKeyDown (KeyCode.DownArrow) == true)) {

			personagemAna.transform.Translate (0, movimento*Time.deltaTime, 0);
			//personagemAna.transform.eulerAngles = new Vector2 (180, 0);
			Ana.SetInteger ("trasicao", 0);

		}else if (Input.GetKey(KeyCode.R)==true){
			//else if ((((Input.GetKey(KeyCode.RightAlt) ==true)||(Input.GetKey(KeyCode.LeftAlt)==true))&&(Input.GetKey (KeyCode.D) == true) || (Input.GetKey (KeyCode.RightArrow) == true))){
			//não funciona
			personagemAna.transform.Translate ((movimento+0.2f)*Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 2);

		}else if (Input.GetKey(KeyCode.E)==true){
			//else if ((((Input.GetKey(KeyCode.RightAlt) ==true)||(Input.GetKey(KeyCode.LeftAlt)==true))&&(Input.GetKey (KeyCode.A) == true) || (Input.GetKey (KeyCode.LeftArrow) == true))){
			//não funciona
			movimento += 0.2f;
			personagemAna.transform.Translate ((movimento+0.2f)*Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 180);
			Ana.SetInteger ("transicao", 2);

		}else if ((Input.GetKey(KeyCode.P) == true)){

			Ana.SetInteger("transicao",4);

		}else if ((Input.GetKeyUp (KeyCode.A) == true)|| (Input.GetKeyUp (KeyCode.LeftArrow) == true)||(Input.GetKeyUp (KeyCode.W) == true) || (Input.GetKeyUp (KeyCode.UpArrow) == true)||(Input.GetKeyUp (KeyCode.D) == true) || (Input.GetKeyUp (KeyCode.RightArrow) == true)||(Input.GetKeyUp(KeyCode.E)==true)||(Input.GetKeyUp(KeyCode.P)==true)||(Input.GetKeyUp(KeyCode.Space) == true)||(Input.GetKeyUp(KeyCode.R)== true)){

			Ana.SetInteger("transicao",0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
		}
	}

	void OnCollisionEnter2D (Collision2D mapa)
	{
		pulo = true;
		print ("colidiu");
	}

	void OnCollisionExit2D (Collision2D mapa)
	{
		pulo = false;
	} 

}
	
