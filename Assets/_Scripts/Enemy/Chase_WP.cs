using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chase_WP : MonoBehaviour
{

    public GameObject player;
    Animator anim;

    string state = "patrol";
    bool patrol = true;
    public GameObject[] waypoints;
    int currentWp = 0;
    public float rotSpeed = 1f;
    public float speed = 1.5f;
    public float speedRun = 3f;
    float accuracyWp = 5.0f;
    public AudioClip[] m_FootstepSounds;
    private AudioSource m_AudioSource;
    int random;
    float distance;
    AnimatorStateInfo clip;


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
        random = Random.Range(0, m_FootstepSounds.Length - 1);
        return m_FootstepSounds[random];
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.fillAmount <= 0)
            return;
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        direction.z = 0;
        float angle = Vector3.Angle(direction, transform.forward);
        distance = Vector3.Distance(player.transform.position, transform.position);
        clip = anim.GetCurrentAnimatorStateInfo(0);

        if (distance < 15)
            patrol = false;
        else
            patrol = true;

        if (patrol)
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("isAttacking_WP", false);
            if (!clip.IsName("Attack_WP"))
            {
                if (Vector3.Distance(waypoints[currentWp].transform.position,
                   transform.position) < accuracyWp)
                {
                    currentWp++;
                    if (currentWp >= waypoints.Length)
                    {
                        currentWp = 0;
                    }
                }
            }

            direction = waypoints[currentWp].transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 1f);
            transform.Translate(0, 0, Time.deltaTime * speed);
        }
        
        else
        {
            anim.SetFloat("Speed", 1);

            if (distance > 3)
            {
                if (!clip.IsName("Attack_WP"))
                {
                    transform.Translate(0, 0, Time.deltaTime * speedRun);
                }
                else
                {
                    transform.Translate(0, 0, 0);
                }

                anim.SetBool("isAttacking_WP", false);
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                     Quaternion.LookRotation(direction), 1f);
            }
            else
            {
                anim.SetBool("isAttacking_WP", true);
            }
        }

    }
}
