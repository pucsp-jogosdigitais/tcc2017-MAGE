using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    public InputManager InManager;
    public GameObject pickupEffect;
    public AudioSource pickupSound;
    public bool teste;
    public Image HP;
    public GameObject press_e;

    private void Start()
    {
        InManager = GameObject.Find("Manager").GetComponent<InputManager>();
        pickupSound = GameObject.Find("Protagonista/Cristal_Vida").GetComponent<AudioSource>();
        HP = GameObject.Find("Canvas/UI/Hp").GetComponent<Image>();
        press_e.SetActive(false);
    }

    //Versão automatica
    /* private void OnTriggerEnter(Collider other)
     {
         if (other.gameObject.tag == "Player")
         {

             // Caso o jogador apertar o botão de interagir
             // if (InManager.m_Interact)
             //{

               Pickup();

             // }
         }

     }*/

    //Jogador precisa estar dentro do Trigger


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
        
        //Verifica se o jogador estiver na area de ação
        if (other.gameObject.tag == "Player")
        {
            teste = true;
            // Caso o jogador apertar o botão de interagir
            if (InManager.m_Get_Objects)
            {
                Pickup();
                teste = false;
                return;
            }
        }


    }

    void Pickup()
    { // Cria um Efeito quando o jogador pegar o item
        Instantiate(pickupEffect, transform.position, transform.rotation);

        pickupSound.Play();

        // Adiciona vida ao jogador

        

        // Deleta o modelo
        Destroy(gameObject);


        if (HP.fillAmount < 1)
        {
            HP.fillAmount += 0.1666666667f;
            return;
        }
    }


}
