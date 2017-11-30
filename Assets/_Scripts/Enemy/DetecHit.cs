using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DetecHit : MonoBehaviour
{

    CharacterManager player;
    public Image HP;
    Animator anim;
    public string opponent;
    public string opponent1;
    public GameObject mao;
    public Collider[] coliders;
    [SerializeField] private AudioClip m_SomAtaque;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_SomHit;
    PauseSwitch ps;
    private float segundos = 0.2f;
    private bool PegandoFogo = false;
    public Rigidbody Golem_rgb;
    public ParticleSystem Hit;
    public AudioClip MagicHitSound;
    private float directionImpulseGolem;

    public bool m_Dead { get; private set; }

    void Start()
    {
        player = GameObject.Find("Protagonista").GetComponent<CharacterManager>();
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        Golem_rgb = GetComponent<Rigidbody>();
        ps = GetComponent<PauseSwitch>();
        //Hit = GetComponent<ParticleSystem>();
        
    }

    void Update()
    {
        if (m_Dead) return;

        DanoFogo();

    }

    private void SomAtaqueGolem()
    {
        AudioClip clip = GetClip();
        m_AudioSource.PlayOneShot(clip);
    }

    private AudioClip GetClip()
    {
        return m_SomAtaque;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != opponent && other.gameObject.tag != opponent1)
        {
            return;
        }


        /*if(gameObject.name == "Golem")
        {
            HP.fillAmount -= 0.51f;
        }*/

        if (other.gameObject.CompareTag("Fireball"))
        {
            directionImpulseGolem = other.transform.position.x - transform.position.x;
            m_AudioSource.PlayOneShot(MagicHitSound);
            DanoMissil();
            Hit.Play();
            if (player.transform.rotation.y > -90)
            {
                Golem_rgb.AddForce(-directionImpulseGolem * 5, 3, 0);
            }
            else if (player.transform.rotation.y < -90)
            {
                Golem_rgb.AddForce(-directionImpulseGolem * 5, 3, 0);
            }
           // transform.Translate(-2, 0, 0);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.name == "Boulder(Clone)")
        {
            //Debug.Log("fudeu");
            Hit.Play();
            m_AudioSource.PlayOneShot(m_SomHit);
            HP.fillAmount -= 1;
            Invoke("gameOver", 1.5f);

        }

        else if (other.gameObject.CompareTag("Fogo"))
        {
            PegandoFogo = true;
        }

        else if (other.gameObject.CompareTag("Soco") && !player.StoneState)
        {
            Hit.Play();
            m_AudioSource.PlayOneShot(m_SomHit);
            transform.Translate(-2, 0, 0);
            DanoSoco();
        }
        else if (other.gameObject.CompareTag("Chute") && !player.StoneState)
        {
            Hit.Play();
            m_AudioSource.PlayOneShot(m_SomHit);
            transform.Translate(-2, 0, 0);
            DanoChute();
        }
        else if (other.gameObject.CompareTag("DeadLine"))
        {
            //Debug.Log("fudeu");
            Hit.Play();
            m_AudioSource.PlayOneShot(m_SomHit);
            HP.fillAmount -= 1;
            gameOver();

        }

    }

    

    void Morrer()
    {
        if (HP.fillAmount <= 0)
        {
            Debug.Log("Morreu");
            anim.SetBool("isDead_Golem", true);
            anim.SetBool("isDead_WP", true);
            anim.SetTrigger("DEAD");
            anim.SetTrigger("Dead_Boss");
            anim.SetBool("isDead", true);
            Invoke("gameOver", 3f);
            Destroy(mao);
            Destroy(HP.gameObject, 3);
            for (int i = 0; i < coliders.Length; i++)
            {
                coliders[i].enabled = false;
            }

            m_Dead = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fogo"))
        {
            PegandoFogo = false;
        }
    }

    private void DanoMissil()
    {
        if (gameObject.CompareTag("Boss"))
        {
            HP.fillAmount -= 0.05f;
        }
        else
        {
            HP.fillAmount -= 0.3f;
        }
        Morrer();
    }

    private void DanoFogo()
    {
        if (!PegandoFogo) return;

        if (segundos > 0f)
        {
            segundos -= Time.deltaTime;

            return;
        }

        if (gameObject.CompareTag("Boss"))
        {
            HP.fillAmount -= 0.01f;
            segundos = 0.2f;
            Morrer();
        }
        else
        {
            HP.fillAmount -= 0.1f;
            segundos = 0.2f;
            Morrer();
        }

    }

    private void DanoSoco()
    {
        HP.fillAmount -= 0.1666666667f;
        Morrer();
    }
    private void DanoChute()
    {
        HP.fillAmount -= 0.1666666667f;
        Morrer();
    }

    private void gameOver()
    {
        ps.GameOverScreen();
    }
}
