using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public static bool alert;
    float ValorEixoZ;
    int valorAleatorio = -1;
    float DistanciaDoPlayer;
    Animator anim;
    public Transform targetPlayer;
    public Transform thisPosition;

    void Start()
    {
        alert = false;
        anim = GetComponent<Animator>();
        if (!targetPlayer)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (!thisPosition)
        {

            Transform[] objs = GetComponentsInChildren<Transform>();
            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i].name == "PosicaoArrumada")
                {
                    thisPosition = objs[i];
                    break;
                }
            }
        }

        ValorEixoZ = transform.position.z;

    }

    void Update()
    {
        TravaPosicao();

        InteragePlayer();


    }


    void TravaPosicao()
    {
        Vector3 posicao = transform.position;
        posicao.z = ValorEixoZ;
        transform.position = posicao;
    }


    void InteragePlayer()
    {
        if (alert)
        {
            Vector3 direcao = targetPlayer.position- transform.position;
            DistanciaDoPlayer = direcao.magnitude;

           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcao, Vector3.up), Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
           

            if (DistanciaDoPlayer < 6)
            {
               // print("esta proximo");
            }
            else
            {
               // print("esta longe");

            }

        }
    }

    void setRandom()
    {
        valorAleatorio = Random.Range(0, 50);
    }

}
