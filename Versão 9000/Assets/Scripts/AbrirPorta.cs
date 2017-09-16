using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour {

    public GameObject Porta, PortaAberta;
    //velocidade porta
    public float VelocidadeP = 2;
    //posicao inicial da porta
    Vector3 posini;
    //obj dentro do trigger
    int numobjdentro;



	// Use this for initialization
	void Start () {

        numobjdentro = 0;
        posini = Porta.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Abrir();
	}
    
    void OnTriggerEnter()
    {
        numobjdentro++;

    }

    void OnTriggerExit()
    {
        numobjdentro--;
        if (numobjdentro < 0)
        {
            numobjdentro = 0;
        }
    }

    public void Abrir()
    {
        if (numobjdentro > 0)
        {
            Porta.transform.localPosition = Vector3.Lerp(Porta.transform.localPosition,
                                            PortaAberta.transform.localPosition,
                                            VelocidadeP * Time.deltaTime);
        }
        else
        {
            Porta.transform.localPosition = Vector3.Lerp(Porta.transform.localPosition,
                                                         posini,
                                                         (VelocidadeP * 0.3f) * Time.deltaTime);
        }

    }

    public void AbrirPuzzle(bool c1,bool c2,bool c3)
    {
        Abrir();
    }
}
