using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruivel : MonoBehaviour
{
    int Cooldown = 1;
    public GameObject destroyedVersion;
    public GameObject Health;
    int rnd;
    public AudioClip[] caixa_break_sound;
    private AudioSource m_audioSource;
    private int random_audio;

    private void Start()
    {
        m_audioSource = GameObject.Find("Protagonista/Som_Caixa").GetComponent<AudioSource>();
    }

    public void Caixa_Sound()
    {
        AudioClip clip = GetRandomAudio();
        m_audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomAudio()
    {
        random_audio = Random.Range(0, caixa_break_sound.Length);
        return caixa_break_sound[random_audio];
    }

    private void DestruirCaixaBreak(GameObject caixa)
    {
        Destroy(caixa);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fireball"))
        {
            rnd = Random.Range(1, 15);
            if (rnd > 10)
            {
                Instantiate(destroyedVersion, gameObject.transform.position, gameObject.transform.rotation);
                Instantiate(Health, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1f), transform.rotation);

                Caixa_Sound();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Caixa_Sound();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
