using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreColision : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Physics.IgnoreLayerCollision(10, 14, true);
		Physics.IgnoreLayerCollision(10, 15, true);
		Physics.IgnoreLayerCollision(10, 16, true);
		Physics.IgnoreLayerCollision(10, 17, true);
		Physics.IgnoreLayerCollision(10, 18, true);
		Physics.IgnoreLayerCollision(17, 18, true);
	}
}
