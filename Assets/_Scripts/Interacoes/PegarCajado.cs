using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCajado : MonoBehaviour
{
    public GameObject CajadoProtagonista, Mago;
    //public Transform Mao, Rotação;
    bool Encima;
    public CharacterManager CharacterM;
    public InputManager InputM;
    public AudioSource pickupSound;
    public ParticleSystem pickupEffect;
    public GameObject press_e;
	public Transform objetoRefInstanciaParticula;

    void Start()
    {
        if (DadosPersistentes.cajado == 1) //Verifica se o jogador já tinha o cajado quando carregou o jogo
        {
            CajadoProtagonista.SetActive(true); //Carrega o cajado na mão do jogador
            //Carrega as habilidades (Apenas para a apresentação)
            CharacterM.SetAtivos(0, "StoneState"); 
            CharacterM.SetAtivos(1, "MagicMissle");
            CharacterM.SetAtivos(2, "FlameThrower");
            CharacterM.SetAtivos(3, "Clone");

            CharacterM.jumpLimit = 2; //Aumenta o limite de pulo do jogador
            Destroy(gameObject); //Destroe o cajado que o jogador iria coletar
        }
        InputM = GameObject.Find("Manager").GetComponent<InputManager>();
        pickupSound = GameObject.Find("Protagonista/Pickup_Cajado").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            press_e.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            press_e.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Mago)
        {
            if (Input.GetButtonDown("Get"))
            {

                CajadoProtagonista.SetActive(true); //Carrega o cajado na mão do jogador
                //Carrega as habilidades (Apenas para a apresentação)
                CharacterM.SetAtivos(0, "StoneState");
                CharacterM.SetAtivos(1, "MagicMissle");
                CharacterM.SetAtivos(2, "FlameThrower");
                CharacterM.SetAtivos(3, "Clone");

                DadosPersistentes.cajado = 1; //Grava na memrória que o jogador tem o cajado 
                CharacterM.jumpLimit = 2; //Aumenta o limite de pulo do jogador

                Instantiate(pickupEffect, objetoRefInstanciaParticula.position, objetoRefInstanciaParticula.rotation, Mago.transform); //Emite uma particula

                pickupEffect.Play();
                Destroy(gameObject); //Destroe o cajado que o jogador iria coletar
                pickupSound.Play();
            }
        }
    }
}
