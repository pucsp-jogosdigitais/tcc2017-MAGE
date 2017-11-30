using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachoeira : MonoBehaviour {

    //public Transform target;
    public AudioSource SomCachoeira;
    bool first = true;

    //Use this for initialization
    private void Awake()
    {
        if(first)
        {
            SomCachoeira.Play();
            first = false;
        }
    }
}
