using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

    GameObject caixa1;
    GameObject caixa2;
    GameObject caixa3;

    bool caixaCheck1 = false;
    bool caixaCheck2 = false;
    bool caixaCheck3 = false;

    AbrirPorta abrir;

	// Use this for initialization
	void Start () {
        caixa1 = FindObjectOfType<GameObject>();
        caixa2 = FindObjectOfType<GameObject>();
        caixa3 = FindObjectOfType<GameObject>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerCollider(Collider other)
    {
        if (other.name == "Player")
        {
            if (caixa1)
            {
                bool caixaCheck1 = true;
            }
            if (caixa2)
            {
                if (caixaCheck1)
                {
                    bool caixaCheck2 = true;
                }
            }
            if (caixa3)
            {
                if (caixaCheck1 && caixaCheck2)
                {
                    bool caixaCheck3 = true;
                }
            }
            else
            {
                caixaCheck1 = false;
                caixaCheck2 = false;
                caixaCheck3 = false;
            }
        }
        
        abrir.AbrirPuzzle(caixaCheck1,caixaCheck2,caixaCheck3);
    }
}
