using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCharacter : MonoBehaviour
{
    public GameObject MissilePrefab, FlamePrefab, ClonePrefab, Player; //Prefab das habilidades
    GameObject[] Golem; //Referência dos golens
    Chase[] chases; //Referencia dos Scripts contidos nos golens
    public CharacterManager CharacterM; //Script referente ao jogador
    public InputManager InputM; //Script referente aos inputs em geral
    private float Duration; //Tempo de animação
    private float CooldownPedra; //Cooldown
    private float CooldownMissil; //Cooldown
    private float CooldownFogo; //Cooldown
    private float CooldownClone; //Cooldown
    public Transform pointWeapon; //Referência da posição de spawn das habilidades na ponta do cajado
    [SerializeField] float MissileSpeed; //Velocidade de deslocamento do míssile mágico
    public Material MatProtag; //Material do modelo do jogador
    public AudioSource SomPedra, SomClone, SomMagicMissile, SomFogo; //Sons das habilidades
    public bool inCooldown; //Verifica se está soltando uma habilidade
    private bool cooldownPedra_bool = false; //Verifica se pode soltar a habilidade
    private bool cooldownMissil_bool = false; //Verifica se pode soltar a habilidade
    private bool cooldownFogo_bool = false; //Verifica se pode soltar a habilidade
    private bool cooldownClone_bool = false; //Verifica se pode soltar a habilidade
    public Image cdPedra; //Imagem da habilidade
    public Image cdMissil; //Imagem da habilidade
    public Image cdFogo; //Imagem da habilidade
    public Image cdClone; //Imagem da habilidade
    public PlayerAnimation setAnim; //Script referente a todas as animações do jogador


    void Start()
    {
        Golem = GameObject.FindGameObjectsWithTag("Enemy"); //Procura todos os golens na cena
        MatProtag.color = Color.white;
    }

    private void Update()
    {
        TempoPedra();
        TempoMissil();
        TempoFogo();
        TempoClone();
    }

    public void StoneState() //Ativa a havilidade de virar pedra
    {
        cooldownPedra_bool = true;
        Duration = 5;
        CooldownPedra = 10;
        if (!inCooldown && cdPedra.fillAmount == 0)
        {
            setAnim.SetSkill("StoneState");
            SomPedra.Play();
            CharacterM.StoneState = true;
            MatProtag.color = new Color(0, 0, 0, 1);
            inCooldown = true;
            StartCoroutine(TimerCount(Duration));
        }
        else
            return;

    }

    public void MagicMissile(Quaternion PersonRotation) //Ativa a havilidade do míssil mágico
    {
        cooldownMissil_bool = true;
        Duration = 1.5f;
        CooldownMissil = 2f;
        if (!inCooldown && cdMissil.fillAmount == 0)
        {
            setAnim.SetSkill("MagicMissle");
            CharacterM.travar = true;
            StartCoroutine(Missle(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;

    }

    public void FlameThrower(Quaternion PersonRotation) //Ativa a havilidade do lança chamas
    {
        cooldownFogo_bool = true;
        Duration = 4.8f;
        CooldownFogo = 27f;
        if (!inCooldown && cdFogo.fillAmount == 0)
        {
            setAnim.SetSkill("FlameThrower");
            CharacterM.travar = true;
            StartCoroutine(Flame(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;

    }

    public void Clone(Quaternion PersonRotation) //Ativa a havilidade do clone
    {
        cooldownClone_bool = true;
        Duration = 0.7f;
        CooldownClone = 25f;
        if (!inCooldown && cdClone.fillAmount == 0)
        {
            setAnim.SetSkill("Clone");
            StartCoroutine(Spawn(Duration, PersonRotation));
            inCooldown = true;
        }
        else
            return;
    }


    private IEnumerator TimerCount(float Cooldown) //Reseta o jogador depois de rodar animação de qualquer habilidade
    {
        yield return new WaitForSeconds(Cooldown);
        CharacterM.travar = false;
        CharacterM.StoneState = false;
        MatProtag.color = Color.white;
        inCooldown = false;
    }

    private void TempoPedra() //Cooldown de virar pedra
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

    private void TempoMissil() //Cooldown do míssil mágico
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

    private void TempoFogo() //Cooldown do lança chamas
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

    private void TempoClone() //Cooldown de duração do clone
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

    private IEnumerator Missle(float Cooldown, Quaternion rotation) //Sincroniza a habilidade com o tempo da animação
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

    private IEnumerator Flame(float Cooldown, Quaternion rotation) //Sincroniza a habilidade com o tempo da animação
    {
        yield return new WaitForSeconds(0.6f);
        GameObject Flame = Instantiate(FlamePrefab, pointWeapon.position, rotation, pointWeapon);
        SomFogo.Play();
        StartCoroutine(TimerCount(Cooldown));
        
    }

    private IEnumerator Spawn(float Cooldown, Quaternion rotation) //Sincroniza a habilidade com o tempo da animação
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

    IEnumerator CloneDuration() //Faz o clone chamar a atenção dos golens
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
