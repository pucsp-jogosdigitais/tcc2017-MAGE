using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBoss : MonoBehaviour {

    Animator animCamera;
    public AudioClip som_HitGround;
    private AudioSource m_AudioSource;
	// Use this for initialization
	void Start () {
        animCamera = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Soco"))
        {
            animCamera.SetBool("Ataque",true);
            m_AudioSource.PlayOneShot(som_HitGround);

        }
        else
            animCamera.SetBool("Ataque", false);
    }
}
