using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCajado : MonoBehaviour
{
    public GameObject CajadoCaido, CajadoProtagonista, Mago;
    //public Transform Mao, Rotação;
    PlataformaFlutuante plataforma;
    bool Encima;
    public CharacterManager CharacterM;
    public InputManager InputM;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Get") && Encima)
        {
            Destroy(gameObject);

            CharacterM.SetAtivos(0, "StoneState");
            CharacterM.SetAtivos(1, "MagicMissle");
            CharacterM.SetAtivos(2, "FlameThrower");
            CharacterM.SetAtivos(3, "Clone");
            DadosPersistentes.cajado = 1;
        }
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
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Mago)
        {
            Encima = true;
        }
    }
}
