using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class PersonagemMove : MonoBehaviour
{
	[SerializeField] float f_MovingTurnSpeed = 360;//Velocidade final da rotação
	[SerializeField] float f_StationaryTurnSpeed = 180;//Velocidade inicial da Rotação
	[SerializeField] float f_JumpPower = 12f;//Força do impulso do pulo
	[SerializeField] float f_Gravity = 14f;
	[SerializeField] float f_VerticalVelocity;
	[Range(1f, 4f)] [SerializeField] float m_GravityMultiplier = 2f;//Slider da velocidade de queda
																	//[SerializeField] float f_RunCycleLegOffset = 0.2f;//Correção do tempo de animação
	[SerializeField] float f_MoveSpeedMultiplier = 1f;//Velocidade de movimento
													  //[SerializeField] float f_AnimSpeedMultiplier = 1f;//Velocidade da animação
													  //[SerializeField] float f_GroundCheckDistance = 0.1f;//Distância do chão

	CharacterController m_Controller;
	Animator m_Animator;
	const float cf_Half = 0.5f;
	float f_TurnAmount;
	float f_ForwardAmount;
	bool b_Jumpping = false;
	Vector3 moveVector;

	void Start()
	{
		m_Animator = GetComponent<Animator>();
		m_Controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		VerificaColisao();
	}

	private void VerificaColisao()
	{
		
	}

	#region RECEBE INTERAÇÃO DO PERSONAGEM  ***enable***
	public void Move(Vector3 move, bool stoneState, bool jump, float f_Horizontal)
	{
		if (stoneState)
		{
			f_VerticalVelocity -= f_Gravity * Time.deltaTime * 10;
			moveVector = new Vector3(0, f_VerticalVelocity, 0);
			m_Controller.Move(moveVector);
			m_Animator.SetBool("Andar", false);
		}
		else
		{
			if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			move = Vector3.ProjectOnPlane(move, Vector3.up);
			f_TurnAmount = Mathf.Atan2(move.y, move.z);
			f_ForwardAmount = move.x;

			ApplyExtraTurnRotation();
			SetAnimation(move, stoneState);

			if (m_Controller.isGrounded)
			{
				b_Jumpping = false;
				f_VerticalVelocity = -f_Gravity * Time.deltaTime;
				if (jump && !b_Jumpping)
				{
					f_VerticalVelocity = f_JumpPower;
					b_Jumpping = true;
				}
			}
			else
			{
				if (b_Jumpping)
				{
					if (jump)
					{
						f_VerticalVelocity = f_JumpPower;
						b_Jumpping = false;
					}
				}
				f_VerticalVelocity -= f_Gravity * Time.deltaTime;
			}

			moveVector = new Vector3(f_Horizontal * f_MoveSpeedMultiplier, f_VerticalVelocity, 0);
			m_Controller.Move(moveVector);
		}
		
	}

	private void SetAnimation(Vector3 move, bool stoneState)
	{
		if (move.x != 0 && !stoneState)
		{
			m_Animator.SetBool("Andar", true);
		}
		else
		{
			m_Animator.SetBool("Andar", false);

		}
	}
	#endregion

	#region APLICA A ROTAÇÃO  ***enable***
	void ApplyExtraTurnRotation()
	{
		float turnSpeed = Mathf.Lerp(f_StationaryTurnSpeed, f_MovingTurnSpeed, f_ForwardAmount);
		transform.Rotate(0, f_TurnAmount * turnSpeed * Time.deltaTime, 0);
	}
	#endregion
}
