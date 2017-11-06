using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

	public static Singleton instance;

	private void Awake()
	{
		instance = this;
	}

	public GameObject player;
}
