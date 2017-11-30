using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
	public Animator m_Animator;

	void Start()
	{
		int Cooldown = 5;
		Physics.IgnoreLayerCollision(15, 10, true);
		//m_Animator.SetBool("Andar", false);
		GetComponent<CharacterController>().Move(new Vector3(0, -1, 0));
		StartCoroutine(TimerCount(Cooldown));
	}

	private IEnumerator TimerCount(int Cooldown)
	{
		yield return new WaitForSeconds(Cooldown);
		Destroy(gameObject);
	}

}
