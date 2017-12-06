using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActivate : MonoBehaviour
{
    public InputManager InManager;
    public InGameMenu menu;
    public GameObject press_e;
    public LevelManager LM;

    public bool bossAlert;

    public Animator Anim;


    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) //Verifica se o jogador está na área de atuação
        {
            Anim.SetBool("PlayerNear", true);


            if (InManager.m_Interact)  //Verifica se o jogador interagiu com o Chekpoint
            {
                if (gameObject.CompareTag("Creditos"))
                {
                    LM.LoadLevel("Creditos");
                }
                else
                {
                    menu.Chekpoint();
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other) //Liga o texto
    {
        if (other.gameObject.tag == "Player")
        {
            press_e.SetActive(true);
        }
    }

    //trecho de codigo novo
    void OnTriggerExit(Collider other) //Desliga todo tipo de interação com o Checkpoint
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", false);
        }
        if (bossAlert)
        {
            Invoke("AlertaBoss", 1.5f);
        }
        if (other.gameObject.tag == "Player")
        {
            press_e.SetActive(false);
        }
    }

    void AlertaBoss()
    {
        BossAI.alert = true;
        print(BossAI.alert);
    }
}
