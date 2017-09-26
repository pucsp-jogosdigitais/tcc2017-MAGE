using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCajado : MonoBehaviour
{
    public GameObject CajadoCaido, CajadoProtagonista, Mago;
    public Transform Mao, Rotação;
    PlataformaFlutuante plataforma;
    bool Encima;
    public CharacterManager CharacterM;
    
    void Start ()
    {

    }
	
	void Update ()
    {
        if (Input.GetButtonDown("Trigger1") && Encima)
        {
            Instantiate(CajadoProtagonista, Mao.transform.position, Rotação.transform.rotation, Mao);
            Destroy(CajadoCaido);
            
            CharacterM.Ativos.Add ("StoneState");
            CharacterM.Ativos.Add ("FlameThrower");
            CharacterM.Ativos.Add ("MagicMissle");
            CharacterM.Ativos.Add ("Clone");
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
