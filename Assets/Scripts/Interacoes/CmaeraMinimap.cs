using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraMinimap : MonoBehaviour {

	Vector3 PosInicial;
	public GameObject Personagem;
	void Start()
	{
		PosInicial = this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Personagem.transform.position + PosInicial;
	}
}
