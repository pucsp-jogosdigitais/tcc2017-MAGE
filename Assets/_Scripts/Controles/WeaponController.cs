using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    private float beginPos;
    private float range = 15f;

    private void Start()
    {
		int Cooldown = 5;
		StartCoroutine(TimerCount(Cooldown));
        //beginPos = transform.position.x;
    }
    private void Update()
    {
        //rg.velocity = new Vector3(1, 0, 0);
        //transform.position = Vector3.forward;
        //if (transform.position.x > beginPos + range || transform.position.x < beginPos - range)
        //{
        //    Destroy(gameObject);
        //}
    }

	private void OnCollisionEnter(Collision collision)
	{
		Destroy(gameObject);
	}

	private IEnumerator TimerCount(int Cooldown)
	{
		yield return new WaitForSeconds(Cooldown);
		Destroy(gameObject);
	}
}