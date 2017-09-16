using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public GameObject player;
    public GameObject Plataforma;
    public Transform PosFinal;
    public Vector3 PosInicial;

	void Start ()
    {
        PosInicial = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Plataforma.transform.localPosition = Vector3.Lerp(PosInicial, PosFinal.transform.position, 0.6f);
        }
    }
}
