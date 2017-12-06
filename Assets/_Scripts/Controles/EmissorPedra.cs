﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissorPedra : MonoBehaviour
{
    //Script responsável pelo funcionamento da armadilha das pedras que caem
    public GameObject boulder;
    public float rateTime = 4;
    void Start()
    {
        InvokeRepeating("Gerador", 1, rateTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Gerador()
    {
        Instantiate(boulder, transform.position,Quaternion.identity);
    }
}
