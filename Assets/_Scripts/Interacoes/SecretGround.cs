using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretGround : MonoBehaviour
{
    //Este script serve apenas para detectar se o personagem estava caindo trasformado em pedra nos terrenos destrutíveis
    CharacterManager player;
    public GameObject destroyedVersion;
    public AudioClip secret_sound;
    private AudioSource m_audioSource;
    void Start()
    {
        player = GameObject.Find("Protagonista").GetComponent<CharacterManager>();
        //m_audioSource = GameObject.Find("Protagonista/Som_Secret").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.StoneState)
            {
                Destroy(gameObject);
                Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation);
                //m_audioSource.PlayOneShot(secret_sound);
            }
        }
    }
}
