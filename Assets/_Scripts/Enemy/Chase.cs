using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase : MonoBehaviour
{

    public GameObject player;
    Animator anim;
    AnimatorStateInfo clip;

    [SerializeField] private AudioClip[] m_FootstepSounds;
    private AudioSource m_AudioSource;
    float distance;
    public Image HP;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        if (m_FootstepSounds.Length > 0)
        {
            AudioClip clip = GetRandomClip();
            m_AudioSource.PlayOneShot(clip);
        }

    }

    private AudioClip GetRandomClip()
    {
        return m_FootstepSounds[UnityEngine.Random.Range(0, m_FootstepSounds.Length)];
    }

    // Update is called once per frame
    public void Update()
    {
        if (HP.fillAmount <= 0)
            return;
        if (this.gameObject.active)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;
            direction.z = 0;
            float angle = Vector3.Angle(direction, transform.forward);
            distance = Vector3.Distance(player.transform.position, transform.position);
            clip = anim.GetCurrentAnimatorStateInfo(0);


            if (distance > 15)
            {
                anim.SetFloat("Speed", 0);
            }
            else
            {
                if (distance > 3)
                {
                    if (!clip.IsName("Attack"))
                        transform.Translate(0, 0, 0.15f);
                    else
                    {
                        transform.Translate(0, 0, 0);
                    }

                    anim.SetBool("isAttacking", false);
                    anim.SetFloat("Speed", 1);
                    transform.rotation = Quaternion.Slerp(transform.rotation,
                                        Quaternion.LookRotation(direction), 1f);
                }
                else
                {
                    anim.SetBool("isAttacking", true);
                }
            }
        }



    }
}
