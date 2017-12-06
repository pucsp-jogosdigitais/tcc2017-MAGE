using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss_Lucas : MonoBehaviour
{

    public Transform player;
    Animator anim;
    [SerializeField] private AudioClip m_FootstepSound;
    private AudioSource m_AudioSource;
    float distance;
    AnimatorStateInfo clip;
    private Quaternion PersonRotation;
    public Image HP;
    private float segundos = 3f;
    public GameObject pe;
    public Animator cameraAnim;
    //public bool fail;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        pe.SetActive(false);
    }

    private void Step()
    {
        //AudioClip clip = GetRandomClip();
        m_AudioSource.PlayOneShot(m_FootstepSound);
    }

    //private AudioClip GetRandomClip()
    //{
    //    return m_FootstepSounds[UnityEngine.Random.Range(0, m_FootstepSounds.Length)];
    //}

    void Update()
    {
        Vector3 posicao = transform.position;
        posicao.z = -4;
        transform.position = posicao;

        if (HP.fillAmount <= 0)
            return;
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        direction.z = 0;
        float angle = Vector3.Angle(direction, transform.forward);
        distance = Vector3.Distance(player.transform.position, transform.position);
        clip = anim.GetCurrentAnimatorStateInfo(0);
        RotationCharacter();

        if (distance > 60)
        {
            anim.SetFloat("Speed", 0);
            pe.SetActive(false);
        }
        else
        {


            if (distance >= 11)
            {
                if (!clip.IsName("Ataque1") && !clip.IsName("Ataque2"))
                {
                    pe.SetActive(false);
                    transform.Translate(0.3f, 0, 0);
                }
                else
                {
                    transform.Translate(0, 0, 0);
                }

                anim.SetBool("Kick_Boss", false);
                anim.SetBool("Ground_Boss", false);
                anim.SetBool("Run_Boss", true);

            }
            else if (distance > 8 && distance < 11)
            {
                if (!clip.IsName("Ataque1") && !clip.IsName("Ataque2"))
                {
                    pe.SetActive(false);
                    transform.Translate(0.15f, 0, 0);
                }
                else
                {
                    transform.Translate(0, 0, 0);
                }

                anim.SetBool("Kick_Boss", false);
                anim.SetBool("Ground_Boss", false);
                anim.SetBool("Run_Boss", false);
                anim.SetFloat("Speed", 0.5f);
            }
            else
            {
                if (distance > 0)
                {
                    anim.SetBool("Kick_Boss", true);
                    anim.SetBool("Ground_Boss", false);
                    pe.SetActive(true);
                    if (!clip.IsName("Movimentacao") && distance < 6)
                        pe.SetActive(false);
                    else
                        pe.SetActive(true);

                }
                if (distance > 7)
                {
                    pe.SetActive(false);
                    anim.SetBool("Kick_Boss", false);
                    anim.SetBool("Ground_Boss", true);
                }
                else
                {
                    anim.SetBool("Ground_Boss", false);
                    anim.SetFloat("Speed", 0);

                }

            }
        }
    }

    public void RotationCharacter()
    {
        if (HP.fillAmount <= 0)
        {
            DelayMorte();
            return;
        }

        if (transform.position.x < player.position.x)
        {
            PersonRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
        }
        else if (transform.position.x > player.position.x)
        {
            PersonRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, PersonRotation, Time.deltaTime * 4);
        }
    }

    private IEnumerator DelayHitGround()
    {
        yield return new WaitForSeconds(2);
    }

    private IEnumerator DelayMorte()
    {
        yield return new WaitForSeconds(5);
    }
}
