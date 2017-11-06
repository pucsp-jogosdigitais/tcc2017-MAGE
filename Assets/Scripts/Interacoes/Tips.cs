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

    void Start()
    {
        dicaTexto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
  
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear",true);


            if (DadosPersistentes.cajado == 1)
            {
                if (_input.m_Interact)
                {
                    dicaTexto.enabled = true;
                    StartCoroutine(Waiting());

                    switch (indexTip)
                    {
                        case 0:
                            CharacterM.jumpLimit = 2;
                            break;
                        case 1:
                            if (!adiquirido)
                            {
                                CharacterM.SetAtivos(0, "MagicMissle");
                                adiquirido = true;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            if (!adiquirido)
                            {
                                CharacterM.SetAtivos(3, "Clone");
                                adiquirido = true;
                            }
                            break;
                        case 5:
                            if (!adiquirido)
                            {
                                CharacterM.SetAtivos(2, "FlameThrower");
                                adiquirido = true;
                            }
                            break;
                        case 6:
                            break;
                        case 7:
                            if (!adiquirido)
                            {
                                CharacterM.SetAtivos(4, "StoneState");
                                adiquirido = true;
                            }
                            break;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", false);
        }
    }

    IEnumerator Waiting ()
    {
        yield return new WaitForSeconds(3);
        dicaTexto.enabled = false;
    }
}
