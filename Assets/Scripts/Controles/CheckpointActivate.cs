using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointActivate : MonoBehaviour
{
	public InputManager InManager;
	public PauseSwitch PaSwitch;

    public bool bossAlert;

    public Animator Anim;

	// Use this for initialization
	private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", true);

            if (InManager.m_Interact)
            {
                PaSwitch.OpenCheckpoint();
            }
        }
	}

    //trecho de codigo novo
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetBool("PlayerNear", false);
        }
        if (bossAlert)
        {
            Invoke("AlertaBoss", 1.5f);
        }
    }

    void AlertaBoss()
    {
        BossAI.alert = true;
        print(BossAI.alert);
    }
}
