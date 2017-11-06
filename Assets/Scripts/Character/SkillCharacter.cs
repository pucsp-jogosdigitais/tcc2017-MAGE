using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCharacter : MonoBehaviour
{
	public GameObject MissilePrefab;
	public GameObject FlamePrefab;
	public GameObject ClonePrefab;
	public CharacterManager CharacterM;
	public InputManager InputM;
	private float Cooldown;
	public Transform pointWeapon;
	[SerializeField] float MissileSpeed;
    public Material MatProtag;
    public AudioSource SomPedra;
    public AudioSource SomClone;
    public AudioSource SomMagicMissile;

    // Use this for initialization
    void Start()
	{

	}

	public void StoneState()
	{
        SomPedra.Play();
		Cooldown = 5;
		CharacterM.StoneState = true;
		MatProtag.color = Color.yellow;
		StartCoroutine(TimerCount(Cooldown));
        
	}

	public void MagicMissile(Quaternion PersonRotation)
	{
		GameObject Missle = Instantiate(MissilePrefab, pointWeapon.position, PersonRotation);
		if (!InputM.right)
		{

			Missle.GetComponent<Rigidbody>().velocity = new Vector3(-MissileSpeed, 0, 0);
            SomMagicMissile.Play();
		}
		else
		{
			Missle.GetComponent<Rigidbody>().velocity = new Vector3(MissileSpeed, 0, 0);
            SomMagicMissile.Play();
        }
	}

	public void FlameThrower(Quaternion PersonRotation)
	{
		GameObject Flame = Instantiate(FlamePrefab, pointWeapon.position, PersonRotation, pointWeapon);
	}

	public void Clone(Quaternion PersonRotation)
	{
		GameObject Clone = Instantiate(ClonePrefab, pointWeapon.position, PersonRotation);
        SomClone.Play();
        
	}

	
	private IEnumerator TimerCount(float Cooldown)
	{
		yield return new WaitForSeconds(Cooldown);
		CharacterM.StoneState = false;
		MatProtag.color = Color.white;
	}
}
