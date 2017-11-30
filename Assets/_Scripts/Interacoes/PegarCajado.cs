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

    void Start()
    {
        if (DadosPersistentes.cajado == 1)
        {
            CajadoProtagonista.SetActive(true);
            CharacterM.SetAtivos(0, "StoneState");
            CharacterM.SetAtivos(1, "MagicMissle");
            CharacterM.SetAtivos(2, "FlameThrower");
            CharacterM.SetAtivos(3, "Clone");
            CharacterM.jumpLimit = 2;
            Destroy(gameObject);
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

                CajadoProtagonista.SetActive(true);
                CharacterM.SetAtivos(0, "StoneState");
                CharacterM.SetAtivos(1, "MagicMissle");
                CharacterM.SetAtivos(2, "FlameThrower");
                CharacterM.SetAtivos(3, "Clone");
                DadosPersistentes.cajado = 1;
                CharacterM.jumpLimit = 2;

                Instantiate(pickupEffect, transform.position, transform.rotation, Mago.transform);

                pickupEffect.Play();
                Destroy(gameObject);
                pickupSound.Play();
            }
        }
    }
}
