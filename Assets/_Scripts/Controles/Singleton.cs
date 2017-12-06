using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    //Script ultlizado para retornar o GameObject do player pra qualquer lugar
	public static Singleton instance;

	private void Awake()
	{
		instance = this;
	}

	public GameObject player;
}
