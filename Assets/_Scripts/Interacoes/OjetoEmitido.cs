using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjetoEmitido : MonoBehaviour
{
    public int Cooldown = 3;
    public AudioSource m_audioSource;

    void Start()
	{
        m_audioSource.Play();
        StartCoroutine(TimerCount(Cooldown));
	}

	// Update is called once per frame
	void Update()
	{

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
