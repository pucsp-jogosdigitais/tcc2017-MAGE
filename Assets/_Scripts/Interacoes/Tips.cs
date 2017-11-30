using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tips : MonoBehaviour
{
    public InputManager _input;
    public TextMeshPro dicaTexto;
    bool adiquirido;
    [SerializeField] int indexTip;
    public CharacterManager CharacterM;
    public Animator Anim;
    [SerializeField] int bloqueio;
    public bool ativado;
    public AudioSource SomConfirmacao;
    void Start()
    {
        dicaTexto.enabled = false;
        ativado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", true);


            if (DadosPersistentes.cajado == 1)
            {
                dicaTexto.enabled = true;
                if (bloqueio == 1)
                {
                    ativado = true;
                    SomConfirmacao.Play();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", false);
            dicaTexto.enabled = false;
        }
    }
}
