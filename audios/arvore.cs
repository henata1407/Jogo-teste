using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arvore : MonoBehaviour {

	public AudioClip arvore1;

	public void OnTriggerEnter2D(Collider2D objeto){

		if (objeto.gameObject.CompareTag ("Player")) {
			
			gerenciador.inst.PlayAudio (arvore1);
			Destroy (gameObject);
		}
	}
}
