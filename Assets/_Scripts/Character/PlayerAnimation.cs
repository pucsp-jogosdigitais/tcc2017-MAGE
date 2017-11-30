using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;
    public CharacterManager playerStats;
    private bool doubleJump;

	public Image HP;

    private void Update()
    {
        //Morreu ();
        playerAnimator.SetBool("LockPosition", playerStats.travar);
    }

	public void Morreu ()
	{
		if (HP.fillAmount <= 0)
			return;
	}

    public void SetWalkAndIdle(float velocity)
    {
		
        if(velocity !=0)
        {
            playerAnimator.SetBool("Walk", true);//Muda de walk pra idle
        }
        else
        {
            playerAnimator.SetBool("Walk", false);
        }
    }
    public void SetJump(int jumpCount, float velocity, int jumpLimite)
    {
        playerAnimator.SetBool("Double", doubleJump);
        playerAnimator.SetBool("OnGround", playerStats.m_Controller.isGrounded);
        playerAnimator.SetInteger("JumpCount", playerStats.jumpCount);//escolhe o tipo de impulso entre pulo ou duplo pulo
        playerAnimator.SetFloat("Jump", velocity);//Alterna entre os 2 estados do pulo
    }
    public void SetDie(int life)
    {
        playerAnimator.SetInteger("Die", life);
    }
    public void SetSkill(string skillID)
    {
        playerAnimator.SetTrigger(skillID);
    }
}
