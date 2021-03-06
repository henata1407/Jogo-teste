using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 

public class movimentacao1 : MonoBehaviour {

	Animator Ana;
	bool botao_mouse;
	int travel;
	//int scrollSpeed = 3;
	public float movimento;
	public float velPulo;
	bool pulo;// verifica se há colisão com um objeto para o pulo acontecer
	Rigidbody2D personagemAna;

	public GameObject coracaoPrefab, coracaoPrefab2;
	public Vector3 coracaoVector, rotacaoCoracao, coracaoVector2, rotacaoCoracao2;
	public GameObject estrelaPrefab,estrelaPrefab2;
	public Vector3 estrelaVector,rotacaoEstrela,estrelaVector2,rotacaoEstrela2;

	int estrelas ;
	int vidas ;

	public Text coracaotxt;
	public Text estrelatxt;
	string aux;

	public GameObject audio1, audio2;

	//Vector3 caixa;
 
	// Use this for initialization
	public void Start () {
		
		pulo = false;
		Ana = GetComponent<Animator> ();
		personagemAna = GetComponent<Rigidbody2D> ();

		estrelas = 0;
		vidas = 3;

		coracaotxt.text = vidas.ToString ();
		estrelatxt.text = estrelas.ToString ();

	}

	// Update is called once per frame
	void Update () {

		if (vidas <= 0) {
			SceneManager.LoadScene ("cutscenedead");
		}

	}

	void FixedUpdate(){

		if ((Input.GetKey (KeyCode.D) == true) || (Input.GetKey (KeyCode.RightArrow) == true)) {

			personagemAna.transform.Translate (movimento * Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 1);

		} else if ((Input.GetKey (KeyCode.A) == true) || (Input.GetKey (KeyCode.LeftArrow) == true)) {

			personagemAna.transform.Translate (movimento * Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 180);
			Ana.SetInteger ("transicao", 1);

		} else if (((Input.GetKeyDown (KeyCode.W) == true) || (Input.GetKeyDown (KeyCode.UpArrow) == true)) && (pulo == false)) {

			personagemAna.AddForce (Vector2.up * velPulo, ForceMode2D.Impulse);
			personagemAna.transform.Translate (0, movimento * Time.deltaTime, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 3);		

		} else if ((Input.GetKeyDown (KeyCode.Space) == true) && (pulo == false) ) {

			personagemAna.AddForce (Vector2.up * velPulo, ForceMode2D.Impulse);
			personagemAna.transform.Translate (0, movimento * Time.deltaTime, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 3);	

		} else if (Input.GetKey (KeyCode.R) == true) {

			personagemAna.transform.Translate ((movimento + 0.2f) * Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);
			Ana.SetInteger ("transicao", 2);

		} else if (Input.GetKey (KeyCode.E) == true) {

			personagemAna.transform.Translate ((movimento + 0.2f) * Time.deltaTime, 0, 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 180);
			Ana.SetInteger ("transicao", 2);

		} else if ((Input.GetKey (KeyCode.P) == true)) {

			Ana.SetInteger ("transicao", 4);
			SceneManager.LoadScene ("cutscenedead");

		} else if ((Input.GetKeyUp (KeyCode.D) == true) || (Input.GetKeyUp (KeyCode.RightArrow) == true)) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		} else if ((Input.GetKeyUp (KeyCode.A) == true) || (Input.GetKeyUp (KeyCode.LeftArrow) == true)) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		} else if ((Input.GetKeyUp (KeyCode.W) == true) || (Input.GetKeyUp (KeyCode.UpArrow) == true)) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		} else if (Input.GetKeyUp (KeyCode.Space) == true) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		} else if (Input.GetKeyUp (KeyCode.R) == true) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		} else if (Input.GetKeyUp (KeyCode.E) == true) {

			Ana.SetInteger ("transicao", 0);
			personagemAna.transform.eulerAngles = new Vector2 (0, 0);

		}
		/* else if ((Input.GetKeyDown (KeyCode.S) == true) || (Input.GetKeyDown (KeyCode.DownArrow) == true)) {
			personagemAna.transform.Translate (0, movimento*Time.deltaTime, 0);
			//personagemAna.transform.eulerAngles = new Vector2 (180, 0);
			Ana.SetInteger ("trasicao", 0);
 
		}*/ //Não é utilizado no jogo , pois não tem animação 
	}



	void OnCollisionEnter2D (Collision2D player)
	{
		if (player.gameObject.CompareTag ("mapa")) {

			pulo = true;
			//print ("colidiu");
		}

		if (player.gameObject.CompareTag ("caixaPeso")) {

			Instantiate (estrelaPrefab, estrelaVector,Quaternion.Euler(rotacaoEstrela));
		}
			

		if (player.gameObject.CompareTag ("porta")) {

			SceneManager.LoadScene ("cutscenedead");
		}
			

	}

	void OnCollisionExit2D (Collision2D mapa)
	{
		if (mapa.gameObject.CompareTag ("mapa")) {

			pulo = false ;
		}

		if (mapa.gameObject.CompareTag ("espinhos")) {

			vidas -= 1;
			coracaotxt.text = vidas.ToString();
		}
			

	}

	void OnCollisionStay2D (Collision2D caixaP){

		if (caixaP.gameObject.CompareTag ("caixaPeso")) {

		//	caixa = caixaP.transform.Translate();
		//	caixa.x -= 1;
			caixaP.transform.Translate ( -3.0f , 0f , 0f);
		}
	}

	private void OnTriggerEnter2D(Collider2D Player){
		
		if (Player.gameObject.CompareTag ("caixa")) {

			Destroy(Player.gameObject);
			Instantiate (coracaoPrefab,coracaoVector,Quaternion.Euler(rotacaoCoracao));
		}

		if (Player.gameObject.CompareTag ("caixa1")) {

			Destroy(Player.gameObject);
			Instantiate (estrelaPrefab, estrelaVector,Quaternion.Euler(rotacaoEstrela));
		}

		if (Player.gameObject.CompareTag ("caixa2")) {

			Destroy(Player.gameObject);
			Instantiate (estrelaPrefab, estrelaVector,Quaternion.Euler(rotacaoEstrela));
		}
		if (Player.gameObject.CompareTag("coracao1")){
			
			Instantiate (audio2, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
			vidas +=1;
			Destroy(Player.gameObject);
			//coracaotxt = vidas.ToString ();
			coracaotxt.text = vidas.ToString();
			Debug.Log ("vidas" + vidas);
		}

		if (Player.gameObject.CompareTag ("estrela")){

			Instantiate (audio1, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
			estrelas += 1;
			Destroy(Player.gameObject);
			//estrelatxt = estrelas.ToString ();
			estrelatxt.text = estrelas.ToString();
			Debug.Log ("estrelas" + estrelas);
		}

		if (Player.gameObject.CompareTag ("pendulo")) {

			vidas -= 1;
			coracaotxt.text = vidas.ToString();
		}

		if (Player.gameObject.CompareTag ("florteste")) {
			
			Destroy (Player.gameObject);
		}

	//	if (Player.gameObject.CompareTag ("som1")) {

	//		Instantiate (audio1, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
	//		Destroy (Player.gameObject);
	//	}

	//	if (Player.gameObject.CompareTag ("som2")) {
			
	//		Instantiate (audio2, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
		//	Destroy (Player.gameObject);
	//	}
				

	}
}
		
