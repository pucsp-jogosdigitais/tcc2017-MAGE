using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cachoeira : MonoBehaviour
{
    //Script responsável pela cutscene da cachoeira
    public AudioSource SomCachoeira;
    bool first = true;

    private void Awake()
    {
        if (first)
        {
            SomCachoeira.Play();
            first = false;
        }
    }
}
