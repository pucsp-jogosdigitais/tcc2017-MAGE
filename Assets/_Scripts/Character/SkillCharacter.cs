using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCharacter : MonoBehaviour
{
    public GameObject MissilePrefab, FlamePrefab, ClonePrefab, Player;
    GameObject[] Golem;
    Chase[] chases;
    public CharacterManager CharacterM;
    public InputManager InputM;
    private float Duration;
    private float CooldownPedra;
    private float CooldownMissil;
    private float CooldownFogo;
    private float CooldownClone;
    public Transform pointWeapon;
    [SerializeField] float MissileSpeed;
    public Material MatProtag;
    public AudioSource SomPedra, SomClone, SomMagicMissile, SomFogo;
    public bool inCooldown;
    private bool cooldownPedra_bool = false;
    private bool cooldownMissil_bool = false;
    private bool cooldownFogo_bool = false;
    private bool cooldownClone_bool = false;
    public Image cdPedra;
    public Image cdMissil;
    public Image cdFogo;
    public Image cdClone;


    // Use this for initialization
    void Start()
    {
        Golem = GameObject.FindGameObjectsWithTag("Enemy");
        MatProtag.color = Color.white;
    }

    private void Update()
    {
        TempoPedra();
        TempoMissil();
        TempoFogo();
        TempoClone();
    }

    public void StoneState()
    {
        cooldownPedra_bool = true;
        Duration = 5;
        CooldownPedra = 10;
        if (!inCooldown && cdPedra.fillAmount == 0)
        {
            SomPedra.Play();
            CharacterM.StoneState = true;
            MatProtag.color = new Color(0, 0, 0, 1);
            inCooldown = true;
            StartCoroutine(TimerCount(Duration));
        }
        else
            return;

    }

    public void MagicMissile(Quaternion PersonRotation)
    {
        cooldownMissil_bool = true;
        Duration = 1.5f;
        CooldownMissil = 3f;
        if (!inCooldown && cdMissil.fillAmount == 0)
        {
            CharacterM.travar = true;
            StartCoroutine(Missle(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;

    }

    public void FlameThrower(Quaternion PersonRotation)
    {
        cooldownFogo_bool = true;
        Duration = 4.8f;
        CooldownFogo = 20f;
        if (!inCooldown && cdFogo.fillAmount == 0)
        {
            CharacterM.travar = true;
            StartCoroutine(Flame(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;

    }

    public void Clone(Quaternion PersonRotation)
    {
        cooldownClone_bool = true;
        Duration = 0.7f;
        CooldownClone = 30f;
        if (!inCooldown && cdClone.fillAmount == 0)
        {
            StartCoroutine(Spawn(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;
    }


    private IEnumerator TimerCount(float Cooldown)
    {
        yield return new WaitForSeconds(Cooldown);
        CharacterM.travar = false;
        CharacterM.StoneState = false;
        MatProtag.color = Color.white;
        inCooldown = false;
    }








    private void TempoPedra()
    {
        if (cooldownPedra_bool)
        {
            cdPedra.fillAmount += 1 / CooldownPedra * Time.deltaTime;
            
            if (cdPedra.fillAmount >= 1)
            {
                cdPedra.fillAmount = 0;
                cooldownPedra_bool = false;
            }
        }
    }

    private void TempoMissil()
    {
        if (cooldownMissil_bool)
        {
            cdMissil.fillAmount += 1 / CooldownMissil * Time.deltaTime;

            if (cdMissil.fillAmount >= 1)
            {
                cdMissil.fillAmount = 0;
                cooldownMissil_bool = false;
            }
        }
    }

    private void TempoFogo()
    {
        if (cooldownFogo_bool)
        {
            cdFogo.fillAmount += 1 / CooldownFogo * Time.deltaTime;

            if (cdFogo.fillAmount >= 1)
            {
                cdFogo.fillAmount = 0;
                cooldownFogo_bool = false;
            }
        }
    }

    private void TempoClone()
    {
        if (cooldownClone_bool)
        {
            cdClone.fillAmount += 1 / CooldownClone * Time.deltaTime;

            if (cdClone.fillAmount >= 1)
            {
                cdClone.fillAmount = 0;
                cooldownClone_bool = false;
            }
        }
    }









    private IEnumerator Missle(float Cooldown, Quaternion rotation)
    {
        yield return new WaitForSeconds(0.6f);
        GameObject Missle = Instantiate(MissilePrefab, pointWeapon.position, rotation);
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
        StartCoroutine(TimerCount(Cooldown));
    }

    private IEnumerator Flame(float Cooldown, Quaternion rotation)
    {
        yield return new WaitForSeconds(0.6f);
        GameObject Flame = Instantiate(FlamePrefab, pointWeapon.position, rotation, pointWeapon);
        SomFogo.Play();
        StartCoroutine(TimerCount(Cooldown));
        
    }

    private IEnumerator Spawn(float Cooldown, Quaternion rotation)
    {
        yield return new WaitForSeconds(1f);
        GameObject clone  = Instantiate(ClonePrefab, pointWeapon.position, rotation);
        for (int i = 0; i < Golem.Length; i++)
        {
            if (Golem[i].name == "Golem")
            {
                Golem[i].GetComponent<Chase>().player = clone;
            }
            if (Golem[i].name == "GolemWP")
            {
                Golem[i].GetComponent<Chase_WP>().player = clone;
            }
        }
        SomClone.Play();
        StartCoroutine(TimerCount(Cooldown));
        StartCoroutine(CloneDuration());
    }

    IEnumerator CloneDuration()
    {
        yield return new WaitForSeconds(7);

        for (int i = 0; i < Golem.Length; i++)
        {
            if (Golem[i].name == "Golem")
            {
                Golem[i].GetComponent<Chase>().player = Player;
            }
            if (Golem[i].name == "GolemWP")
            {
                Golem[i].GetComponent<Chase_WP>().player = Player;
            }
        }
    }
}
