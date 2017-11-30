using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraMinimap : MonoBehaviour {

	Vector3 PosInicial, PosPersonagem;
	public GameObject Personagem;
	void Start()
	{
		PosInicial = this.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
        PosPersonagem = new Vector3(Personagem.transform.position.x, Personagem.transform.position.y, 0);
        transform.position = PosPersonagem + PosInicial;
	}
}
