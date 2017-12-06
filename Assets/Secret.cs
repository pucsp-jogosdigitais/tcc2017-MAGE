using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour {

    private Rigidbody secret_rgb;
	// Use this for initialization

    private void OnEnable()
    {
        secret_rgb = gameObject.GetComponent<Rigidbody>();
        secret_rgb.AddForce(Random.insideUnitSphere * 5000);
        Destroy(gameObject, 10);
    }
}
