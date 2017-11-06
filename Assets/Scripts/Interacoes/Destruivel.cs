using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruivel : MonoBehaviour
{
	int Cooldown = 1;
	public GameObject destroyedVersion;

	private void OnCollisionEnter(Collision collision)
	{
		if (gameObject.name == "barril Especial(Clone)")
		{
			Instantiate(destroyedVersion, transform.position, transform.rotation);
			gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag("Fireball"))
		{
			Instantiate(destroyedVersion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
