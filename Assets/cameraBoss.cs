using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBoss : MonoBehaviour {

    public Animator animCamera;
    public AudioClip som_HitGround;
    public AudioSource m_AudioSource;
	
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Soco"))
        {
            Debug.Log("Colidiu");
            animCamera.Play("CameraBoss");
            m_AudioSource.PlayOneShot(som_HitGround);
        }
    }
}
