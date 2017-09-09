using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PersonagemMove))]
public class ControladorMove : MonoBehaviour
{
	private PersonagemMove m_Player;
	private Vector3 m_Move;
	public bool m_Jump;
	// Use this for initialization
	void Start()
	{
		m_Player = GetComponent<PersonagemMove>();
	}

	// Update is called once per frame
	void Update()
	{
		m_Jump = Input.GetButtonDown("Jump");
	}

	private void FixedUpdate()
	{
		// read inputs
		float h = Input.GetAxis("Horizontal");
		bool stoneState = Input.GetButton("Fire3");

		// calculate move direction to pass to character
		m_Move = h * Vector3.right;

		// pass all parameters to the character control script
		m_Player.Move(m_Move, stoneState, m_Jump, h);
		m_Jump = false;

	}
}
