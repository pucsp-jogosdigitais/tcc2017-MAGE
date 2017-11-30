using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Destruivel : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "barril Especial(Clone)")
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
