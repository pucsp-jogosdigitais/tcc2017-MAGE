using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlay : MonoBehaviour
{

    public Animator anim;
    public AudioSource cutscene_sound;
    public CharacterManager player;
    bool first = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && first)
        {
            anim.SetBool("Triggered", true);
            cutscene_sound.Play();
            player.travar = true;
            player.Travar();
            first = false;
            StartCoroutine(animWainting());
        }
    }

    IEnumerator animWainting()
    {
        yield return new WaitForSeconds(5);
        player.travar = false;
    }
}
