using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //Mod Externo
    public GameObject player;
    public NavMeshAgent nav;
    public Animator anim;
    public EnemyHealth health;
    //Variavel
    public float remaing;
    //Condicionais
    public bool playerInRange, playerInAttack;
    bool count;

    void Awake ()
    {
        //Iniciando
        //player = GameObject.FindGameObjectWithTag ("Player");
        health = GetComponent<EnemyHealth>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        //Se não tiver apanhando, corre atrás do jogador

        if(playerInAttack)
        {

        }
        else
        {

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            playerInAttack = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInAttack = false;
        }
    }
    //Se parar de apanhar volta a andar atras do jogador

}
