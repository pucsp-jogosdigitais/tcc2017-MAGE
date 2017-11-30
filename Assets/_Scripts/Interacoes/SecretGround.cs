using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGround : MonoBehaviour
{
    CharacterManager player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Protagonista").GetComponent<CharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(player.StoneState)
                Destroy(gameObject);
        }
    }
}
