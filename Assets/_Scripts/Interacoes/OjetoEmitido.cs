using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjetoEmitido : MonoBehaviour
{
    //Script resposável pelo comportamento da bola de pedra
    public int Cooldown = 3;
    public AudioSource m_audioSource;

    void Start()
	{
        m_audioSource.Play();
        StartCoroutine(TimerCount(Cooldown));
	}

	private IEnumerator TimerCount(int Cooldown)
	{
		yield return new WaitForSeconds(Cooldown);
		Destroy(gameObject);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            Destroy(gameObject);
        }
    }
}
